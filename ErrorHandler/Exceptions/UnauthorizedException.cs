using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YuraSoft.ErrorHandler.Exceptions
{
	public class UnauthorizedException : HandableException
	{
		private const string _defaultMessage = "Unauthorized";

		/// <summary>
		/// Constructor
		/// </summary>
		public UnauthorizedException() : this(_defaultMessage)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		public UnauthorizedException(string message) : this(message, (Dictionary<string, List<string>>?)null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="modelState">Model state</param>
		public UnauthorizedException(ModelStateDictionary modelState) : this(_defaultMessage, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="errors">Dictionary with errors</param>
		public UnauthorizedException(Dictionary<string, List<string>>? errors) : this(_defaultMessage, errors)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="modelState">Model state</param>
		public UnauthorizedException(string message, ModelStateDictionary? modelState) : base(StatusCodes.Status401Unauthorized, message, modelState)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message</param>
		/// <param name="errors">Dictionary with errors</param>
		public UnauthorizedException(string message, Dictionary<string, List<string>>? errors) : base(StatusCodes.Status401Unauthorized, message, errors)
		{
		}
	}
}
