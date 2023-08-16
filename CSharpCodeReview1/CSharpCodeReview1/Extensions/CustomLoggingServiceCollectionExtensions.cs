using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CSharpCodeReview1.Extensions
{
    /// <summary>
    /// Extension methods for setting up custom configuration services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class CustomLoggingServiceCollectionExtensions
    {
        /// <summary>
        /// Adds custom logging configurations to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddCustomLogging(this IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning);
                builder.AddFilter("System", LogLevel.Warning);
                builder.AddConsole();
            });
            return services;
        }
    }
}
