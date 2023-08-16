using CSharpCodeReview1.Domain;
using CSharpCodeReview1.Domain.Interfaces;
using CSharpCodeReview1.Domain.Interfaces.Infrastructure;
using CSharpCodeReview1.Functions;
using CSharpCodeReview1.Functions.Interfaces;
using CSharpCodeReview1.Infrastructure.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace CSharpCodeReview1
{
    public class Program
    {
        public static void Main()
        {
            // Application innit
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddFilter("Microsoft", LogLevel.Warning);
                    builder.AddFilter("System", LogLevel.Warning);
                    builder.AddConsole();
                })
                .AddSingleton(config)
                .AddSingleton<IExecutableProcess, ImportEmployeesFromFile>()
                .AddSingleton<IEmployeesService, EmployeesService>()
                .AddSingleton<IEmployeeQueryRepository, FileEmployeeQueryRepository>()
                .AddSingleton<IEmployeePersistanceRepository, SqlServerEmployeePersistanceRepository>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger?.LogInformation("Process startup finished successfuly, starting function execution.");

            ExecuteFunctions(serviceProvider);
        }

        public static void ExecuteFunctions(IServiceProvider serviceProvider)
        {
            var employeesImportFunction = serviceProvider.GetService<IExecutableProcess>();
            employeesImportFunction?.Execute();
        }
    }
}