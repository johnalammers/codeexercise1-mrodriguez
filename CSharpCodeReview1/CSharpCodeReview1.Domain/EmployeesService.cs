using CSharpCodeReview1.Domain.Interfaces.Infrastructure;
using CSharpCodeReview1.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace CSharpCodeReview1.Domain
{
    public class EmployeesService : IEmployeesService
    {
        private readonly ILogger<EmployeesService> _logger;
        private readonly IEmployeeQueryRepository _employeeQueryRepository;
        private readonly IEmployeePersistanceRepository _employeePersistanceRepository;

        public EmployeesService(ILogger<EmployeesService> logger, IEmployeeQueryRepository employeeQueryRepository, IEmployeePersistanceRepository employeePersistanceRepository)
        {
            _logger = logger;
            _employeeQueryRepository = employeeQueryRepository;
            _employeePersistanceRepository = employeePersistanceRepository;
        }

        public void ImportEmployees()
        {
            try
            {
                _logger.LogInformation("Retrieving all the employees to import");
                var employees = _employeeQueryRepository.GetEmployees();

                foreach (var (employee, index) in employees.Select((employee, index) => (employee, index)))
                {
                    _logger.LogInformation($"Position {index} has employee {employee.FullName}");
                }

                _logger.LogInformation("Attempting to persist employees in the database");
                _employeePersistanceRepository.PersistEmployees(employees);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Unable to process employees, errors were found.", ex);
            }
        }
    }
}