using CSharpCodeReview1.Domain.Models.Entities;

namespace CSharpCodeReview1.Domain.Interfaces.Infrastructure
{
    /// <summary>
    /// Exposes methods for querying <see cref="Employee"/> entities.
    /// </summary>
    public interface IEmployeeQueryRepository
    {
        /// <summary>
        /// Retrieves a collection of <see cref="Employee"/> entities.
        /// </summary>
        /// <returns>A collection of <see cref="Employee"/> entities.</returns>
        IEnumerable<Employee> GetEmployees();
    }
}
