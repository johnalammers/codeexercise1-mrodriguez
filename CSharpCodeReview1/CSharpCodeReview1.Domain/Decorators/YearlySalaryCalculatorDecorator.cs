using CSharpCodeReview1.Domain.Interfaces.Decorators;

namespace CSharpCodeReview1.Domain.Decorators
{
    /// <summary>
    /// Decorator class that calculates the yearly salary by multiplying the person's monthly salary by 12.
    /// </summary>
    internal class YearlySalaryCalculatorDecorator : ISalariedPerson
    {
        private const int MONTHS_OF_YEAR = 12;
        private readonly ISalariedPerson _person;

        public YearlySalaryCalculatorDecorator(ISalariedPerson person)
        {
            _person = person;
        }

        /// <summary>
        /// Calculates the yearly salary by multiplying the monthly salary by 12.
        /// </summary>
        /// <returns>The calculated yearly salary.</returns>
        public virtual decimal GetSalary()
        {
            return _person.GetSalary() * MONTHS_OF_YEAR;
        }
    }
}
