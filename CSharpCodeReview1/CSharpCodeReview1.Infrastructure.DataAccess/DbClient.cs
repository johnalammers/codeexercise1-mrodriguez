namespace CSharpCodeReview1.Infrastructure.DataAccess
{
    /// <summary>
    /// A database client class that is a wrapper for a sql server connection
    /// </summary>
    public class DbClient
    {
        private readonly string _connectionString;

        public DbClient(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void CloseDbConnection()
        {
            throw new NotImplementedException();
        }

        public void OpenDbConnection()
        {
            throw new NotImplementedException();
        }

        public void RunQuery(string insertSql)
        {
            throw new NotImplementedException();
        }
    }
}