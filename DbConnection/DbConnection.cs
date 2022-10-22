using System;

namespace DatabaseConnection
{
    abstract class DbConnection
    {
        private bool DbConnectionStatus;
        
        protected string ConnectionString { get; set; }
        
        protected TimeSpan Timeout { get; set; }
        
        protected DateTime ConnectionRequestDateTime { get; set; }

        public DbConnection(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString)) //if null or empty string is passed execution stops
            {
                throw new ArgumentNullException(nameof(connectionString) + "IsNullOrWhiteSpace");

            }
            ConnectionString = connectionString;
            DbConnectionStatus = false;
        }

        public bool GetDbConnectionStatus()
        {
            return DbConnectionStatus;
        }

        protected void SetDbConnectionStatus(bool status)
        {
            DbConnectionStatus = status;
        }
        
        public abstract  void OpenConnection(string connectionString, TimeSpan timeout );
        
        public abstract void CloseConnection();
    }
}
