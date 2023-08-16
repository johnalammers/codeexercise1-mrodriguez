using CSharpCodeReview1.Extensions;
using CSharpCodeReview1.Functions.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CSharpCodeReview1
{
    public class Program
    {
        public static void Main()
        {
            // Application innit
            var serviceProvider = new ServiceCollection()
                .AddCustomLogging()
                .AddCustomConfigurations()
                .AddCustomDependencies()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger?.LogInformation("Process startup finished successfuly, starting function execution.");

            ExecuteFunctions(serviceProvider);
        }

        public static void ExecuteFunctions(IServiceProvider serviceProvider)
        {
            // In the possible scenario where we need to execute more processes, here we can handle a list
            // of delegates, or, if the ThreadPool is needed, tasks, and dispatch them.
            //
            // This methods is intended to be used in this specific example.
            var employeesImportFunction = serviceProvider.GetService<IExecutableProcess>();
            employeesImportFunction?.Execute();
        }
    }
}