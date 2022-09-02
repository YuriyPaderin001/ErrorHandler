using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YuraSoft.ExceptionHandler.Exceptions
{
	/// <summary>
	/// Handable exception
	/// </summary>
	public class HandableException : Exception, IHandableException
	{
		protected readonly int _statusCode;
		protected readonly Dictionary<string, List<string>>? _errors;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="statusCode">Status code</param>
		/// <param name="message">Message</param>
		public HandableException(int statusCode, string message) : base(message)
		{
			_statusCode = CheckStatusCode(nameof(statusCode), statusCode);
			CheckMessage(nameof(message), message);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="statusCode">Status code</param>
		/// <param name="message">Message</param>
		/// <param name="modelState">Model state</param>
		public HandableException(int statusCode, string message, ModelStateDictionary? modelState) : base(message)
		{
			_statusCode = CheckStatusCode(nameof(statusCode), statusCode);
			CheckMessage(nameof(message), message);

			_errors = modelState?.Where(ms => ms.Value.ValidationState == ModelValidationState.Invalid)
				.ToDictionary(k => k.Key, v => v.Value.Errors.Select(e => e.ErrorMessage).ToList());
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="statusCode">Status code</param>
		/// <param name="message">Message</param>
		/// <param name="errors">Dictionary with errors</param>
		public HandableException(int statusCode, string message, Dictionary<string, List<string>>? errors) : base(message)
		{
			_statusCode = CheckStatusCode(nameof(statusCode), statusCode);
			CheckMessage(nameof(message), message);

			_errors = errors;
		}

		/// <summary>
		/// Get exception response method
		/// </summary>
		/// <returns>Returns exception response</returns>
		public virtual IExceptionResponse ToExceptionResponse()
		{
			ExceptionResponse errorData = new ExceptionResponse(_statusCode, Message, _errors);

			return errorData;
		}

		/// <summary>
		/// Status code check method
		/// </summary>
		/// <param name="parameterName">Parameter name</param>
		/// <param name="statusCode">Status code</param>
		/// <returns>Returns status code or throw ArgumentException</returns>
		/// <exception cref="ArgumentException"></exception>
		private static int CheckStatusCode(string parameterName, int statusCode)
		{
			if (statusCode < 400 || statusCode > 599)
			{
				throw new ArgumentException($"{parameterName} must be between 400 and 599. Current value: {statusCode}");
			}

			return statusCode;
		}

		/// <summary>
		/// Message check method
		/// </summary>
		/// <param name="parameterName">Parameter name</param>
		/// <param name="message">Message</param>
		/// <returns>Returns message or throw ArgumentException</returns>
		/// <exception cref="ArgumentException"></exception>
		private static string CheckMessage(string parameterName, string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				throw new ArgumentException($"{parameterName} cannot be null or empty");
			}

			return message;
		}
	}
}
