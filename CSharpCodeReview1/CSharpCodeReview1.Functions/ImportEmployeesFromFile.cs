using CSharpCodeReview1.Domain.Interfaces.Services;
using CSharpCodeReview1.Functions.Interfaces;
using Microsoft.Extensions.Logging;

namespace CSharpCodeReview1.Functions
{
    public class ImportEmployeesFromFile : IExecutableProcess
    {
        private readonly ILogger<ImportEmployeesFromFile> _logger;
        private readonly IEmployeesService _employeesService;

        public ImportEmployeesFromFile(IEmployeesService employeesService, ILogger<ImportEmployeesFromFile> logger)
        {
            _employeesService = employeesService;
            _logger = logger;
        }

        public void Execute()
        {
            _logger.LogInformation("Importing employees from file");
            _employeesService.ImportEmployees();
        }
    }
}
