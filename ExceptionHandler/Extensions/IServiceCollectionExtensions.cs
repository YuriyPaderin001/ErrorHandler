using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace YuraSoft.ExceptionHandler
{
	/// <summary>
	/// Class with extension methods of IServiceCollectionExtensions
	/// </summary>
	public static class IServiceCollectionExtensions
	{
		/// <summary>
		/// Method for adding default exception handler
		/// </summary>
		/// <param name="services">Service collection</param>
		/// <returns>Returns service collection</returns>
		public static IServiceCollection AddDefaultErrorHandler(this IServiceCollection services) =>
			services.AddSingleton<IExceptionHandler, ExceptionHandler>(sp =>
			{
				ILogger logger = sp.GetRequiredService<ILogger<ExceptionHandler>>();

				ExceptionHandler exceptionHandler = new ExceptionHandler(logger);

				return exceptionHandler;
			});

		/// <summary>
		/// Method for adding exception handler
		/// </summary>
		/// <typeparam name="TExceptionHandler">Exception handler generic type</typeparam>
		/// <param name="services">Service collection</param>
		/// <returns>Returns service collection</returns>
		public static IServiceCollection AddExceptionHandler<TExceptionHandler>(this IServiceCollection services)
			where TExceptionHandler : class, IExceptionHandler => 
			services.AddSingleton<IExceptionHandler, TExceptionHandler>();

		/// <summary>
		/// Method for adding exception handler
		/// </summary>
		/// <typeparam name="TExceptionHandler">Exception handler generic type</typeparam>
		/// <param name="services">Service collection</param>
		/// <param name="implementationFactory">Implementation factory</param>
		/// <returns>Returns service collection</returns>
		public static IServiceCollection AddExceptionHandler<TExceptionHandler>(this IServiceCollection services, 
			Func<IServiceProvider, TExceptionHandler> implementationFactory) where TExceptionHandler : class, IExceptionHandler =>
			services.AddSingleton<IExceptionHandler, TExceptionHandler>(implementationFactory);
	}
}
