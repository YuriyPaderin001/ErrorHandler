using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YuraSoft.ErrorHandler.Exceptions
{
	public class ConflictException : HandableException
	{
		private const string _defaultMessage = "Conflict";

		/// <summary>
		/// Constructor
		/// </summary>
		public ConflictException() : this(_defaultMessage)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		public ConflictException(string message) : this(message, (Dictionary<string, List<string>>?)null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="modelState">Model state</param>
		public ConflictException(ModelStateDictionary modelState) : this(_defaultMessage, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="errors">Dictionary with errors</param>
		public ConflictException(Dictionary<string, List<string>>? errors) : this(_defaultMessage, errors)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="modelState">Model state</param>
		public ConflictException(string message, ModelStateDictionary? modelState) : base(StatusCodes.Status409Conflict, message, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="errors">Dictionary with errors</param>
		public ConflictException(string message, Dictionary<string, List<string>>? errors) : base(StatusCodes.Status409Conflict, message, errors)
		{
		}
	}
}
