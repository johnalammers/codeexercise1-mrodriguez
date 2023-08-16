using CSharpCodeReview1.Domain.Interfaces;
using CSharpCodeReview1.Domain.Interfaces.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CSharpCodeReview1.Domain
{
    public class EmployeesService : IEmployeesService
    {
        private readonly ILogger<EmployeesService> _logger;
        private readonly IEmployeeQueryRepository _employeeQueryRepository;

        public EmployeesService(ILogger<EmployeesService> logger, IEmployeeQueryRepository employeeQueryRepository)
        {
            _logger = logger;
            _employeeQueryRepository = employeeQueryRepository;
        }

        public void ImportEmployees()
        {
            _logger.LogInformation("Retrieving all the employees to import");
            var employees = _employeeQueryRepository.GetEmployees();

            foreach (var (employee, index) in employees.Select((employee, index) => (employee, index)))
            {
                _logger.LogInformation($"Position {index} has employee {employee.FullName}");
            }

            _logger.LogInformation("Attempting to persist employees in the database");
        }
    }
}