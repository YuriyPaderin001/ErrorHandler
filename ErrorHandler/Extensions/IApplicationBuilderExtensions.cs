using Microsoft.AspNetCore.Builder;

namespace YuraSoft.ErrorHandler
{ 
	/// <summary>
	/// Extension class of IApplicationBuilder
	/// </summary>
	public static class IApplicationBuilderExtensions
	{
		/// <summary>
		/// Method for adding error handler middleware
		/// </summary>
		/// <param name="app">Application builder</param>
		/// <returns>Returns application builder</returns>
		public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
		{
			return app.UseMiddleware<ErrorHandlerMiddleware>();
		}
	}
}
