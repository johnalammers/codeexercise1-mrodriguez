using CSharpCodeReview1.Domain.Models.Entities;

namespace CSharpCodeReview1.Domain.Interfaces.Infrastructure
{
    /// <summary>
    /// Exposes methods for persisting <see cref="Employee"/> entities.
    /// </summary>
    public interface IEmployeePersistanceRepository
    {
        /// <summary>
        /// Persists a collection of <see cref="Employee"/> entities.
        /// </summary>
        /// <param name="employees">The collection of <see cref="Employee"/> entities to be persisted.</param>
        /// <returns>The number of rows affected by the query.</returns>
        int PersistEmployees(IEnumerable<Employee> employees);
    }
}
