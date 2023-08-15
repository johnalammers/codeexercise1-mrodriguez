using CSharpCodeReview1.Functions;
using CSharpCodeReview1.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                .AddSingleton<IConfiguration>(config)
                .AddSingleton<IExecutableProcess, ImportEmployeesFromFile>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger?.LogInformation("Process startup finished successfuly, starting function execution.");

            // Execute process
            var employeesImportFunction = serviceProvider.GetService<IExecutableProcess>();
            employeesImportFunction?.Execute();
        }
    }
}