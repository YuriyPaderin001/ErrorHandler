using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YuraSoft.ErrorHandler.Exceptions
{
	public class InternalServerErrorException : HandableException
	{
		private const string _defaultMessage = "Internal Server Error";

		/// <summary>
		/// Constructor
		/// </summary>
		public InternalServerErrorException() : this(_defaultMessage)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		public InternalServerErrorException(string message) : this(message, (Dictionary<string, List<string>>?)null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="modelState">Model state</param>
		public InternalServerErrorException(ModelStateDictionary modelState) : this(_defaultMessage, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="errors">Dictionary with errors</param>
		public InternalServerErrorException(Dictionary<string, List<string>>? errors) : this(_defaultMessage, errors)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="modelState">Model state</param>
		public InternalServerErrorException(string message, ModelStateDictionary? modelState) : base(StatusCodes.Status500InternalServerError, message, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="errors">Dictionary with errors</param>
		public InternalServerErrorException(string message, Dictionary<string, List<string>>? errors) : base(StatusCodes.Status500InternalServerError, message, errors)
		{
		}
	}
}
