using CSharpCodeReview1.Domain.Interfaces.Decorators;

namespace CSharpCodeReview1.Domain.Decorators
{
    /// <summary>
    /// Decorator class that calculates the salary after applying taxes to a person's salary.
    /// </summary>
    internal class TaxedSalaryCalculatorDecorator : ISalariedPerson
    {
        private readonly ISalariedPerson _person;
        private readonly decimal _taxRate;

        public TaxedSalaryCalculatorDecorator(ISalariedPerson person, decimal taxRate)
        {
            // We can now remove this from the employee and manager entities
            // public static decimal TaxRate => 0.21M;
            _person = person;
            _taxRate = taxRate;
        }

        /// <summary>
        /// Calculates the salary after applying the tax rate.
        /// </summary>
        /// <returns>The salary after tax deduction.</returns>
        public virtual decimal GetMonthlySalary()
        {
            return _person.GetMonthlySalary() * (1 - _taxRate);
        }
    }
}
