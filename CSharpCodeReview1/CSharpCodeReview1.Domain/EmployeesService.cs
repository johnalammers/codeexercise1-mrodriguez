using CSharpCodeReview1.Domain.Models;
using Microsoft.Extensions.Logging;

namespace CSharpCodeReview1.Domain
{
    public class EmployeesService
    {
        private readonly ILogger<EmployeesService> _logger;

        public EmployeesService(ILogger<EmployeesService> logger)
        {
            _logger = logger;
        }

        public List<Employee> GetEmployees()
        {
            _logger.LogInformation("Retrieving employees");
            return new List<Employee>();
        }

        public void StoreEmployees()
        {
            _logger.LogInformation("Saving employees");
        }
    }
}