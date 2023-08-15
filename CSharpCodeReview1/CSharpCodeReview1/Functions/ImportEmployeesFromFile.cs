using CSharpCodeReview1.Domain.Models;
using CSharpCodeReview1.Infrastructure.DataAccess;
using CSharpCodeReview1.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpCodeReview1.Functions
{
    internal class ImportEmployeesFromFile : IExecutableProcess
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        public ImportEmployeesFromFile(ILogger<ImportEmployeesFromFile> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void Execute()
        {
            _logger.LogInformation("Starting execution of Employees Import");
            DbClient dbClient;
            List<Employee> employees = new();
            var filename = _config.GetRequiredSection("EmployeeListFileName").Get<string>() ?? string.Empty;
            var connStr = _config.GetRequiredSection("DbClientConnString").Get<string>() ?? string.Empty;

            dbClient = new DbClient(connStr);
            dbClient.OpenDbConnection();
            try
            {
                StreamReader streamReader = new(filename);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    employees.Add(ParseRow(line));

                    SaveToDb(ParseRow(line), dbClient);
                }

                streamReader.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            foreach (var (employee, index) in employees.Select((employee, index) => (employee, index)))
            {
                _logger.LogInformation($"Position {index} has ID of {employee.Id} and name of {employee.FullName}");
            }

            dbClient.CloseDbConnection();
        }

        /// <summary>
        /// Parses a cvs text string to an employee object
        /// </summary>
        /// <param name="csvDataRow"></param>
        /// <returns></returns>
        private Employee ParseRow(string csvDataRow)
        {
            // you can assume all fields are present and in the order of
            // Firstname, Lastname, Jobtitle, Birthday, Salary
            try
            {
                // pretend parsing code is here 

                return new Employee(
                    Employee.NextID,
                    "John ", "Doe", "Engineer",
                    DateTime.Parse("1980-5-3"), 5000.00);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new InvalidOperationException(ex.Message);
            }
        }

        private void SaveToDb(Employee employee, DbClient dbClient)
        {
            string insertSql =
                $"insert into employees (id, firstname, lastname, jobtitle) VALUES " +
                $"({employee.Id}, '{employee.FirstName}', '{employee.LastName}', '{employee.JobTitle}')";

            dbClient.RunQuery(insertSql);
        }
    }
}
