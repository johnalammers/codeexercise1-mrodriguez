namespace CSharpCodeReview1.Domain.Interfaces.Decorators
{
    /// <summary>
    /// Represents a person that earns a monthly salary
    /// </summary>
    public interface ISalariedPerson
    {
        /// <summary>
        /// Gets the monthly salary earned by the person.
        /// </summary>
        /// <returns>The monthly salary.</returns>
        decimal GetMonthlySalary();
    }
}
