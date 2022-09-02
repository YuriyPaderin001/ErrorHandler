using System;
using System.Collections.Generic;

namespace YuraSoft.ExceptionHandler
{
	/// <summary>
	/// Exception response
	/// </summary>
	public class ExceptionResponse : IExceptionResponse
	{
		private string _message;
		private int _statusCode;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Error message</param>
		/// <param name="statusCode">HTTP status code between 400 and 599</param>
		/// <param name="errors">Key value dictionary with invalid parameters</param>
		/// <exception cref="ArgumentException"></exception>
		public ExceptionResponse(int statusCode, string message, Dictionary<string, List<string>>? errors = null)
		{
			_message = CheckMessage(nameof(message), message);
			_statusCode = CheckStatusCode(nameof(statusCode), statusCode);

			Errors = errors;
		}

		/// <summary>
		/// Error message
		/// </summary>
		public string Message 
		{ 
			get => _message; 
			set => _message = CheckMessage(nameof(Message), value); 
		}

		/// <summary>
		/// HTTP status code
		/// </summary>
		public int StatusCode 
		{ 
			get => _statusCode; 
			set => _statusCode = CheckStatusCode(nameof(StatusCode), value); 
		}

		/// <summary>
		/// Key value pair list of invalid request parameters
		/// </summary>
		public Dictionary<string, List<string>>? Errors { get; set; }

		/// <summary>
		/// Type check method
		/// </summary>
		/// <param name="parameterName">Parameter name</param>
		/// <param name="type">Type</param>
		/// <returns>Returns type or throw exception</returns>
		/// <exception cref="ArgumentException"></exception>
		private static string CheckMessage(string parameterName, string type)
		{
			if (string.IsNullOrEmpty(type))
			{
				throw new ArgumentException($"{parameterName} connot be null or empty");
			}

			return type;
		}

		/// <summary>
		/// Status code check method
		/// </summary>
		/// <param name="parameterName">Parameter name</param>
		/// <param name="statusCode">Status code</param>
		/// <returns>Returns status code or throw exception</returns>
		/// <exception cref="ArgumentException"></exception>
		private static int CheckStatusCode(string parameterName, int statusCode)
		{
			if (statusCode < 400 || statusCode > 599)
			{
				throw new ArgumentException($"{parameterName} must be between 400 and 599. Current value: {statusCode}");
			}

			return statusCode;
		}
	}
}
