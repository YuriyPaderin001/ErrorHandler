using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YuraSoft.ExceptionHandler.Exceptions
{
	public class MethodNotAllowedException : HandableException
	{
		private const string _defaultMessage = "Method Not Allowed";

		/// <summary>
		/// Constructor
		/// </summary>
		public MethodNotAllowedException() : this(_defaultMessage)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		public MethodNotAllowedException(string message) : this(message, (Dictionary<string, List<string>>?)null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="modelState">Model state</param>
		public MethodNotAllowedException(ModelStateDictionary modelState) : this(_defaultMessage, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="errors">Dictionary with errors</param>
		public MethodNotAllowedException(Dictionary<string, List<string>>? errors) : this(_defaultMessage, errors)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="modelState">Model state</param>
		public MethodNotAllowedException(string message, ModelStateDictionary? modelState) : base(StatusCodes.Status405MethodNotAllowed, message, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="errors">Dictionary with errors</param>
		public MethodNotAllowedException(string message, Dictionary<string, List<string>>? errors) : base(StatusCodes.Status405MethodNotAllowed, message, errors)
		{
		}
	}
}
