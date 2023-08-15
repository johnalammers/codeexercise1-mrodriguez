using CSharpCodeReview1.Functions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace CSharpCodeReview1
{
    public static class Program
    {
        static void Main()
        {
            // Application innit
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
            });

            IConfiguration config = builder.Build();

            // Execute process
            var employeesImportFunction = new ImportEmployeesFromFile(loggerFactory.CreateLogger<ImportEmployeesFromFile>(), config);
            employeesImportFunction.Execute();
        }
    }
}