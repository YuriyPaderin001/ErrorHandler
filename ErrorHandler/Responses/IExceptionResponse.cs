using System.Collections.Generic;

namespace YuraSoft.ExceptionHandler
{
	/// <summary>
	/// Exception response interface
	/// </summary>
	public interface IExceptionResponse
	{
		/// <summary>
		/// Message
		/// </summary>
		public string Message { get; }

		/// <summary>
		/// HTTP status code
		/// </summary>
		public int StatusCode { get; }

		/// <summary>
		/// Key value pair enumerable of invalid request parameters
		/// </summary>
		public Dictionary<string, List<string>>? InvalidParameters { get; }
	}
}
