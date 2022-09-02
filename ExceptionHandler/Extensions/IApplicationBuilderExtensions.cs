using Microsoft.AspNetCore.Builder;

using YuraSoft.ExceptionHandler.Middleware;

namespace YuraSoft.ExceptionHandler
{ 
	/// <summary>
	/// Class with extension methods of IApplicationBuilder
	/// </summary>
	public static class IApplicationBuilderExtensions
	{
		/// <summary>
		/// Method for adding error handler middleware
		/// </summary>
		/// <param name="app">Application builder</param>
		/// <returns>Returns application builder</returns>
		public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app) => 
			app.UseMiddleware<ExceptionHandlerMiddleware>();
	}
}
