using CSharpCodeReview1.Domain.Models;
using CSharpCodeReview1.Domain.Models.Exceptions;

namespace CSharpCodeReview1.Infrastructure.DataAccess
{
    public static class Helpers
    {
        /// <summary>
        /// Parses a cvs text string to an employee object. All fields are present and in the order of
        /// Firstname, Lastname, Jobtitle, Birthday, Salary
        /// </summary>
        /// <param name="csvDataRow">A line containing an employee's information delimited by comma</param>
        /// <returns>An object of type Employee</returns>
        /// <exception cref="EmployeeParsingException">Thrown if there's an error parsing the CSV data</exception>
        public static Employee ParseRow(string csvDataRow)
        {
            try
            {
                string[] fields = csvDataRow.Split(',');
                return new Employee
                {
                    FirstName = fields[0],
                    LastName = fields[1],
                    JobTitle = fields[2],
                    BirthDate = DateTime.Parse(fields[3]),
                    MonthlySalary = decimal.Parse(fields[4])
                };
            }
            catch (Exception ex)
            {
                throw new EmployeeParsingException($"Unable to parse line {csvDataRow}", ex);
            }
        }
    }
}
