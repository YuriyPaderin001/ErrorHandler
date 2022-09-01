using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace YuraSoft.ErrorHandler
{
	/// <summary>
	/// Extension class of IServiceCollection
	/// </summary>
	public static class IServiceCollectionExtensions
	{
		/// <summary>
		/// Method for adding default error handler
		/// </summary>
		/// <param name="services">Service collection</param>
		/// <returns>Returns service collection</returns>
		public static IServiceCollection AddDefaultErrorHandler(this IServiceCollection services)
		{
			return services.AddSingleton<IErrorHandler, ErrorHandler>(sp =>
			{
				ILogger logger = sp.GetRequiredService<ILogger<ErrorHandler>>();

				ErrorHandler exceptionHandler = new ErrorHandler(logger);

				return exceptionHandler;
			});
		}

		/// <summary>
		/// Method for adding exception handler
		/// </summary>
		/// <typeparam name="TExceptionHandler">Exception handler generic type</typeparam>
		/// <param name="services">Service collection</param>
		/// <returns>Returns service collection</returns>
		public static IServiceCollection AddExceptionHandler<TExceptionHandler>(this IServiceCollection services)
			where TExceptionHandler : class, IErrorHandler
		{
			return services.AddSingleton<IErrorHandler, TExceptionHandler>();
		}

		/// <summary>
		/// Method for adding exception handler
		/// </summary>
		/// <typeparam name="TExceptionHandler">Exception handler generic type</typeparam>
		/// <param name="services">Service collection</param>
		/// <param name="implementationFactory">Implementation factory</param>
		/// <returns>Returns service collection</returns>
		public static IServiceCollection AddExceptionHandler<TExceptionHandler>(this IServiceCollection services, Func<IServiceProvider, TExceptionHandler> implementationFactory)
			where TExceptionHandler : class, IErrorHandler
		{
			return services.AddSingleton<IErrorHandler, TExceptionHandler>(implementationFactory);
		}
	}
}
