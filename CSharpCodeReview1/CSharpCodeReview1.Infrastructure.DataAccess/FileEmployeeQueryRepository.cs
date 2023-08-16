using CSharpCodeReview1.Domain.Interfaces.Infrastructure;
using CSharpCodeReview1.Domain.Models;
using CSharpCodeReview1.Domain.Models.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CSharpCodeReview1.Infrastructure.DataAccess
{
    /// <summary>
    /// Provides operations for parsing employee data from a file and retrieving them as Employee objects.
    /// Implements the <see cref="IEmployeeQueryRepository"/> interface.
    /// </summary>
    public class FileEmployeeQueryRepository : IEmployeeQueryRepository
    {
        private readonly ILogger<FileEmployeeQueryRepository> _logger;
        private readonly IConfiguration _config;

        public FileEmployeeQueryRepository(ILogger<FileEmployeeQueryRepository> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = new();
            var filename = _config.GetRequiredSection("EmployeeListFileName").Get<string>() ?? string.Empty;
            _logger.LogInformation($"Starting execution of Employees Import from {filename}");

            try
            {
                using (StreamReader streamReader = new(filename))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        employees.Add(Helpers.ParseRow(line));
                    }
                }
            }
            catch (EmployeeParsingException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error found while trying to access and read the Employees file {filename}");
                throw new EmployeeParsingException(ex.Message, ex);
            }

            return employees;
        }
    }
}
