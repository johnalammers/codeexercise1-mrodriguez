using CSharpCodeReview1.Domain.Interfaces.Decorators;

namespace CSharpCodeReview1.Domain.Models.Entities
{
    public abstract class Person : ISalariedPerson
    {
        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string FullName { get => $"{FirstName} {LastName}"; }

        public string JobTitle { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public decimal MonthlySalary { get; set; }

        public override string ToString() => $"NAME: {FullName}; JOB:{JobTitle}; SALARY: {MonthlySalary}";

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Employee otherEmployee = (Employee)obj;
            return Id == otherEmployee.Id &&
                   FirstName == otherEmployee.FirstName &&
                   LastName == otherEmployee.LastName &&
                   BirthDate == otherEmployee.BirthDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName, BirthDate);
        }

        /// <summary>
        /// Gets the salary earned by month.
        /// </summary>
        /// <returns></returns>
        public virtual decimal GetSalary() => MonthlySalary;

        /*
        * These methods will be delegated to decorators
        * 
        * GetYearlySalary: Can be calculated using the YearlySalaryCalculatorDecorator
        * ApplyTaxRateToSalary: Can be calculated using TaxedSalaryCalculatorDecorator
        */

        /// <summary>
        /// Method to count sum of 12 salaries (one per month) of the employee
        /// based on attribute monthlySalaryCZK
        /// </summary>
        /// <returns>Sum of all the 12 salaries</returns>
        //public virtual decimal GetYearlySalary()
        //{
        //    // The following method originaly had these comments:
        //    // Method to count sum of 12 salaries(one per month) of the employee
        //    // based on attribute monthlySalaryCZK
        //    //
        //    // Where there any different calculation algorithms depending on the country?
        //    // I will asume that there will probably be different approaches.
        //    return MonthlySalary * 12;
        //}


        /// <summary>
        /// Method to calculate salary after taxation
        /// </summary>
        /// <param name="salary">Salary of employee</param>
        /// <returns>Salary after to taxation</returns>
        //protected virtual decimal ApplyTaxRateToSalary(decimal salary)
        //{
        //    return salary * (1 - TaxRate);
        //}
    }
}