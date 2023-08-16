using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace CSharpCodeReview1.Extensions
{
    /// <summary>
    /// Extension methods for setting up custom configuration services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class CustomConfigurationsServiceCollectionExtensions
    {
        /// <summary>
        /// Adds custom configurations to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            services.AddSingleton(config);
            return services;
        }
    }
}
