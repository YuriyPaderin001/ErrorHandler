using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YuraSoft.ExceptionHandler.Middleware
{
	/// <summary>
	/// Exception handler middleware
	/// </summary>
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IExceptionHandler _handler;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="next">Request delegate</param>
		/// <param name="ExceptionHandler">Exception handler</param>
		public ExceptionHandlerMiddleware(RequestDelegate next, IExceptionHandler handler)
		{
			_next = next;
			_handler = handler;
		}

		/// <summary>
		/// Invoke method
		/// </summary>
		/// <param name="context">HTTP context</param>
		/// <returns>Returns task</returns>
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception ex)
			{
				await _handler.HandleException(context, ex);
			}
		}
	}
}
