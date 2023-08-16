using CSharpCodeReview1.Domain.Interfaces.Decorators;

namespace CSharpCodeReview1.Domain.Decorators
{
    internal class BonusPerEmployeeSalaryCalculatorDecorator : ISalariedPerson
    {
        private readonly ISalariedPerson _person;
        private readonly int _employeesCount;
        private readonly decimal _salaryBonusPerEmployee;

        /// <summary>
        /// Decorator class that calculates the salary by adding a bonus for each employee.
        /// </summary>
        public BonusPerEmployeeSalaryCalculatorDecorator(ISalariedPerson person, int employeesCount, decimal salaryBonusPerEmployee)
        {
            /* In the old code, the salary bonus per employee had this rule:
             *
             *  {
             *      get => perEmployeeSalaryBonus;
             *      set
             *      {
             *      if (value >= 0.0M)
             *          perEmployeeSalaryBonus = value;
             *      }
             *  }
             *
             *I will use this for the calculations for now, and let the Manager class to have any value it is set.
             */

            _person = person;
            _employeesCount = employeesCount;
            _salaryBonusPerEmployee = salaryBonusPerEmployee >= 0.0M ? salaryBonusPerEmployee : default;
        }

        /// <summary>
        /// Calculates the salary by adding a bonus for each employee.
        /// </summary>
        /// <returns>The calculated salary with the bonus for employees.</returns>
        public virtual decimal GetMonthlySalary()
        {
            decimal baseSalary = _person.GetMonthlySalary();
            decimal totalBonus = _employeesCount * _salaryBonusPerEmployee;
            return baseSalary + totalBonus;
        }
    }
}
