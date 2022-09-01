using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YuraSoft.ErrorHandler.Exceptions
{
	public class ForbiddenException : HandableException
	{
		private const string _defaultMessage = "Forbidden";

		/// <summary>
		/// Constructor
		/// </summary>
		public ForbiddenException() : this(_defaultMessage)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		public ForbiddenException(string message) : this(message, (Dictionary<string, List<string>>?)null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="modelState">Model state</param>
		public ForbiddenException(ModelStateDictionary modelState) : this(_defaultMessage, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="errors">Dictionary with errors</param>
		public ForbiddenException(Dictionary<string, List<string>>? errors) : this(_defaultMessage, errors)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="modelState">Model state</param>
		public ForbiddenException(string message, ModelStateDictionary? modelState) : base(StatusCodes.Status403Forbidden, message, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="errors">Dictionary with errors</param>
		public ForbiddenException(string message, Dictionary<string, List<string>>? errors) : base(StatusCodes.Status403Forbidden, message, errors)
		{
		}
	}
}
