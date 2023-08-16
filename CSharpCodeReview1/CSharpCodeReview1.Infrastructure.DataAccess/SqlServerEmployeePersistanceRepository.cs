using CSharpCodeReview1.Domain.Interfaces.Infrastructure;
using CSharpCodeReview1.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CSharpCodeReview1.Infrastructure.DataAccess
{
    /// <summary>
    /// Provides operations for persisting employee data into a SQL Server database.
    /// Implements the <see cref="IEmployeePersistanceRepository"/> interface.
    /// </summary>
    public class SqlServerEmployeePersistanceRepository : IEmployeePersistanceRepository
    {
        private readonly ILogger<SqlServerEmployeePersistanceRepository> _logger;
        private readonly IConfiguration _config;

        public SqlServerEmployeePersistanceRepository(ILogger<SqlServerEmployeePersistanceRepository> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public int PersistEmployees(IEnumerable<Employee> employees)
        {
            using var dbClient = new DbClient(_config.GetRequiredSection("DbClientConnString").Get<string>() ?? string.Empty);
            try
            {
                int rowsAffected = 0;
                string insertSql =
                    "INSERT INTO employees (firstname, lastname, jobtitle) VALUES (@FirstName, @LastName, @JobTitle)";

                foreach (var employee in employees)
                {
                    var parameters = new Dictionary<string, object>
                {
                    { "@FirstName", employee.FirstName },
                    { "@LastName", employee.LastName },
                    { "@JobTitle", employee.JobTitle }
                };

                    rowsAffected += dbClient.RunQuery(insertSql, parameters);
                }

                dbClient.CommitTransaction();
                return rowsAffected;
            }
            catch (Exception e)
            {
                _logger.LogError("Could not persist employees into database, rolling back changes...", e);
                dbClient.RollbackTransaction();
                return 0;
            }
        }
    }
}
