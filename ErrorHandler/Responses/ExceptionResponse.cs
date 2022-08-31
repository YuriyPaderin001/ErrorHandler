using System;
using System.Collections.Generic;

namespace YuraSoft.ExceptionHandler
{
	/// <summary>
	/// Exception response
	/// </summary>
	public class ExceptionResponse : IExceptionResponse
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="statusCode">HTTP status code between 400 and 599</param>
		/// <param name="message">Message</param>
		/// <param name="invalidParameters">Key value dictionary with invalid parameters</param>
		/// <exception cref="ArgumentException"></exception>
		public ExceptionResponse(int statusCode, string message, Dictionary<string, List<string>>? invalidParameters = null)
		{
			if (statusCode < 400 || statusCode > 599)
			{
				throw new ArgumentException($"statusCode must be between 400 and 599. Current value: {statusCode}.");
			}

			if (string.IsNullOrEmpty(message))
			{
				throw new ArgumentException("message cannot be null or empty.");
			}

			StatusCode = statusCode;
			Message = message;
			InvalidParameters = invalidParameters;
		}

		/// <summary>
		/// Message
		/// </summary>
		public string Message { get; private set; }

		/// <summary>
		/// HTTP status code
		/// </summary>
		public int StatusCode { get; private set; }

		/// <summary>
		/// Key value pair list of invalid request parameters
		/// </summary>
		public Dictionary<string, List<string>>? InvalidParameters { get; private set; }
	}
}
