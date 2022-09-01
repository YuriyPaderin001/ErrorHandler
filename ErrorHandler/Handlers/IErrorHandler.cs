using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YuraSoft.ErrorHandler
{
	/// <summary>
	/// Error handler interface
	/// </summary>
	public interface IErrorHandler
	{
		public ValueTask HandleException(HttpContext httpContext, Exception exception);
	}
}
