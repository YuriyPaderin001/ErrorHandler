using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YuraSoft.ExceptionHandler
{
	/// <summary>
	/// Error handler interface
	/// </summary>
	public interface IExceptionHandler
	{
		public Task HandleException(HttpContext httpContext, Exception exception);
	}
}
