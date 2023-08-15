using System;

namespace CSharpCodeReview1
{
    internal class DbClient
    {
        private readonly string _connectionString;

        public DbClient(string connectionString)
        {
            this._connectionString = connectionString;
        }

        internal void CloseDbConnection()
        {
            throw new NotImplementedException();
        }

        internal void OpenDbConnection()
        {
            throw new NotImplementedException();
        }

        internal void RunQuery(string insertSql)
        {
            throw new NotImplementedException();
        }
    }
}