using System.Data.SqlClient;

namespace CSharpCodeReview1.Infrastructure.DataAccess
{
    /// <summary>
    /// A database client class that is a wrapper for a SQL Server connection.
    /// Provides methods to run parameterized queries and manage the connection's lifecycle.
    /// Implements the IDisposable interface to properly dispose of resources.
    /// Supports transactions for executing multiple queries as a single unit of work.
    /// </summary>
    public class DbClient : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        /// <summary>
        /// Initializes a new instance of the DbClient class with the specified connection string.
        /// Opens the database connection and starts a transaction upon creation.
        /// </summary>
        /// <param name="connectionString">The connection string for the SQL Server database.</param>
        public DbClient(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// Runs a parameterized SQL query on the connected database within the ongoing transaction.
        /// </summary>
        /// <param name="query">The SQL query to execute.</param>
        /// <param name="parameters">Optional dictionary of parameter names and values for the query.</param>
        /// <returns>The number of rows affected by the query.</returns>
        public int RunQuery(string query, Dictionary<string, object>? parameters = null)
        {
            using SqlCommand command = new(query, _connection, _transaction);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// Commits the ongoing transaction, persisting the changes to the database.
        /// </summary>
        public void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
            _transaction = null;
        }

        /// <summary>
        /// Rolls back the ongoing transaction, discarding any changes made within it.
        /// </summary>
        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        /// <summary>
        /// Disposes of the resources associated with the database client.
        /// If a transaction is ongoing, rolls it back before closing and disposing the connection.
        /// </summary>
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
