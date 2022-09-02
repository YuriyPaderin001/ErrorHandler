using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YuraSoft.ExceptionHandler.Exceptions
{
	public class BadRequestException : HandableException
	{
		private const string _defaultMessage = "Bad Request";

		/// <summary>
		/// Constructor
		/// </summary>
		public BadRequestException() : this(_defaultMessage)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		public BadRequestException(string message) : this(message, (Dictionary<string, List<string>>?)null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="modelState">Model state</param>
		public BadRequestException(ModelStateDictionary modelState) : this(_defaultMessage, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="errors">Dictionary with errors</param>
		public BadRequestException(Dictionary<string, List<string>>? errors) : this(_defaultMessage, errors)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="modelState">Model state</param>
		public BadRequestException(string message, ModelStateDictionary? modelState) : base(StatusCodes.Status400BadRequest, message, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="errors">Dictionary with errors</param>
		public BadRequestException(string message, Dictionary<string, List<string>>? errors) : base(StatusCodes.Status400BadRequest, message, errors)
		{
		}
	}
}
