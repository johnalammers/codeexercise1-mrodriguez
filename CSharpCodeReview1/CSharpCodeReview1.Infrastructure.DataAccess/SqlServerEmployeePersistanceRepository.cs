using CSharpCodeReview1.Domain.Interfaces.Infrastructure;
using CSharpCodeReview1.Domain.Models;

namespace CSharpCodeReview1.Infrastructure.DataAccess
{
    /// <summary>
    /// Provides operations for persisting employee data into a SQL Server database.
    /// Implements the <see cref="IEmployeePersistanceRepository"/> interface.
    /// </summary>
    public class SqlServerEmployeePersistanceRepository : IEmployeePersistanceRepository
    {
        private readonly DbClient _dbClient;

        public SqlServerEmployeePersistanceRepository(DbClient dbClient)
        {
            _dbClient = dbClient;
        }

        public void PersistEmployees(IEnumerable<Employee> employees)
        {

            //string insertSql =
            //    $"insert into employees (id, firstname, lastname, jobtitle) VALUES " +
            //    $"({employee.Id}, '{employee.FirstName}', '{employee.LastName}', '{employee.JobTitle}')";

            //_dbClient.RunQuery(insertSql);
        }
    }
}
