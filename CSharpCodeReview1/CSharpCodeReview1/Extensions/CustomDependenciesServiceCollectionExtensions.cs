using CSharpCodeReview1.Domain;
using CSharpCodeReview1.Domain.Interfaces.Infrastructure;
using CSharpCodeReview1.Domain.Interfaces.Services;
using CSharpCodeReview1.Functions;
using CSharpCodeReview1.Functions.Interfaces;
using CSharpCodeReview1.Infrastructure.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpCodeReview1.Extensions
{
    /// <summary>
    /// Extension methods for setting up custom configuration services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class CustomDependenciesServiceCollectionExtensions
    {
        /// <summary>
        /// Adds custom service dependencies to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddCustomDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IExecutableProcess, ImportEmployeesFromFile>();
            services.AddSingleton<IEmployeesService, EmployeesService>();
            services.AddSingleton<IEmployeeQueryRepository, FileEmployeeQueryRepository>();
            services.AddSingleton<IEmployeePersistanceRepository, SqlServerEmployeePersistanceRepository>();
            return services;
        }
    }
}
