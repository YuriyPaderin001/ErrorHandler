using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YuraSoft.ExceptionHandler
{
	/// <summary>
	/// Error handler middleware
	/// </summary>
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IExceptionHandler _exceptionHandler;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="next">Request delegate</param>
		/// <param name="exceptionHandler">Exception handler</param>
		public ExceptionHandlerMiddleware(RequestDelegate next, IExceptionHandler exceptionHandler)
		{
			_next = next;
			_exceptionHandler = exceptionHandler;
		}

		/// <summary>
		/// Invoke method
		/// </summary>
		/// <param name="context">HTTP context</param>
		/// <returns>Returns task</returns>
		public async ValueTask InvokeAsync(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception ex)
			{
				await _exceptionHandler.HandleException(context, ex);
			}
		}
	}
}
