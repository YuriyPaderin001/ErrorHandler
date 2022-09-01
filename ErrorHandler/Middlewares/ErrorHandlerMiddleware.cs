using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YuraSoft.ErrorHandler
{
	/// <summary>
	/// Error handler middleware
	/// </summary>
	public class ErrorHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IErrorHandler _errorHandler;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="next">Request delegate</param>
		/// <param name="errorHandler">Error handler</param>
		public ErrorHandlerMiddleware(RequestDelegate next, IErrorHandler errorHandler)
		{
			_next = next;
			_errorHandler = errorHandler;
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
				await _errorHandler.HandleException(context, ex);
			}
		}
	}
}
