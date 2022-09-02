using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YuraSoft.ExceptionHandler.Exceptions
{
	public class NotFoundException : HandableException
	{
		private const string _defaultMessage = "Not Found";

		/// <summary>
		/// Constructor
		/// </summary>
		public NotFoundException() : this(_defaultMessage)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		public NotFoundException(string message) : this(message, (Dictionary<string, List<string>>?)null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="modelState">Model state</param>
		public NotFoundException(ModelStateDictionary modelState) : this(_defaultMessage, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="errors">Dictionary with errors</param>
		public NotFoundException(Dictionary<string, List<string>>? errors) : this(_defaultMessage, errors)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="modelState">Model state</param>
		public NotFoundException(string message, ModelStateDictionary? modelState) : base(StatusCodes.Status404NotFound, message, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="errors">Dictionary with errors</param>
		public NotFoundException(string message, Dictionary<string, List<string>>? errors) : base(StatusCodes.Status404NotFound, message, errors)
		{
		}
	}
}
