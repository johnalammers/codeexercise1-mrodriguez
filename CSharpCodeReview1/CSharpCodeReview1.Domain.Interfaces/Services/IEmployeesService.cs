namespace CSharpCodeReview1.Domain.Interfaces.Services
{
    /// <summary>
    /// Represents a service for importing employees from one data source to another.
    /// </summary>
    public interface IEmployeesService
    {
        /// <summary>
        /// Imports employees from a source data storage to a target data storage.
        /// </summary>
        void ImportEmployees();
    }
}