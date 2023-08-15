using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

            ILogger logger = loggerFactory.CreateLogger("Program");

            logger.LogError("error");
            logger.LogWarning("warning");
            logger.LogInformation("info");

            IConfiguration config = builder.Build();

            DbClient dbClient;
            List<Employee> employeeArray = new();
            var filename = config.GetRequiredSection("EmployeeListFileName").Get<string>() ?? string.Empty;
            var connStr = config.GetRequiredSection("DbClientConnString").Get<string>() ?? string.Empty;

            dbClient = new DbClient(connStr);
            dbClient.OpenDbConnection();
            try
            {
                StreamReader streamReader = new(filename);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    employeeArray.Add(ParseRow(line, logger));

                    SaveToDb(ParseRow(line, logger), dbClient);
                }

                streamReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            for (var i = 0; i <= employeeArray.Count; i++)
            {
                logger.LogInformation($"Position {i} has ID of {employeeArray[i].Id} and name of {employeeArray[i].FullName}");
            }

            dbClient.CloseDbConnection();
        }

        /// <summary>
        /// Parses a cvs text string to an employee object
        /// </summary>
        /// <param name="csvdatarow"></param>
        /// <returns></returns>
        private static Employee ParseRow(string csvdatarow, ILogger logger)
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
                logger.LogError(ex.Message);
            }
        }

        private static void SaveToDb(Employee employee, DbClient dbClient)
        {
            string insertSql =
                $"insert into employees (id, firstname, lastname, jobtitle) VALUES " +
                $"({employee.Id}, '{employee.FirstName}', '{employee.LastName}', '{employee.JobTitle}')";

            dbClient.RunQuery(insertSql);
        }
    }
}