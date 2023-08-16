using CSharpCodeReview1.Domain.Models;

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
        void PersistEmployees(IEnumerable<Employee> employees);
    }
}
