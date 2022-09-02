using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace YuraSoft.ExceptionHandler
{
	/// <summary>
	/// Default error handler
	/// </summary>
	public class ExceptionHandler : IExceptionHandler
	{
		private ILogger _logger;
		private JsonSerializerOptions? _options;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="logger">Logger</param>
		/// <param name="options">Serialization options</param>
		public ExceptionHandler(ILogger logger, JsonSerializerOptions? options = null)
		{
			_logger = logger;
			_options = options;
		}

		/// <summary>
		/// Handle error method
		/// </summary>
		/// <param name="httpContext">HTTP context</param>
		/// <param name="exception">Exception</param>
		/// <returns>Returns task</returns>
		public virtual async Task HandleException(HttpContext httpContext, Exception exception)
		{
			_logger.LogDebug("Handle exception. Request method: {method}, uri: {path}{query}. Exception: {@exception}", 
				httpContext.Request.Method, httpContext.Request.Path, httpContext.Request.QueryString, exception);

			IExceptionResponse exceptionResponse;
			if (exception is IHandableException handableException)
			{
				exceptionResponse = handableException.ToExceptionResponse();

				_logger.LogInformation(exceptionResponse.Message);
			}
			else
			{
				string fullMessage = GetFullExceptionMessage(exception);

				exceptionResponse = new ExceptionResponse(StatusCodes.Status500InternalServerError, "Internal Server Error");

				_logger.LogError(fullMessage);
			}

			string exceptionResponseJson = JsonSerializer.Serialize(exceptionResponse, exceptionResponse.GetType(), _options);

			httpContext.Response.StatusCode = exceptionResponse.StatusCode;
			await httpContext.Response.WriteAsync(exceptionResponseJson);

			_logger.LogDebug("Handle exception... OK. Request method: {method}, uri: {path}{query}. Exception: {@exception}",
				httpContext.Request.Method, httpContext.Request.Path, httpContext.Request.QueryString, exception);
		}

		/// <summary>
		/// Get full exception message method
		/// </summary>
		/// <param name="exception">Exception</param>
		/// <returns>Returns full exception message</returns>
		private static string GetFullExceptionMessage(Exception exception)
		{
			StringBuilder stringBuilder = new StringBuilder(exception.Message);

			Exception? innerException = exception.InnerException;
			while (innerException != null)
			{
				stringBuilder.Append(innerException.Message);
				stringBuilder.Append(". ");

				innerException = innerException.InnerException!;
			}

			return stringBuilder.ToString();
		}
	}
}
