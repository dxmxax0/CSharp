using System;
using System.Threading;

namespace DatabaseConnection
{
    class OracleConnection : DbConnection
    { 
        public OracleConnection(string connectionString)
            : base(connectionString){}
    
        public override void OpenConnection(string connectionString, TimeSpan timeout)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString) + " IsNullOrWhiteSpace");
            }
            else if (connectionString == ConnectionString)
            {
                ConnectionRequestDateTime = DateTime.UtcNow;
                Thread.Sleep(1000); //this thread sleeps 1s to test timeout
                if (DateTime.UtcNow - ConnectionRequestDateTime >= timeout)
                {
                    throw new ArgumentException("Oracle DB connection request is timeouted.");
                }
                SetDbConnectionStatus(true);
                Timeout = timeout;
                Console.WriteLine("Oracle DB connection is opened.");
            }
            else
                Console.WriteLine("Wrong connection string. Oracle DB connection cannot opened.");
        }

        public override void CloseConnection()
        {

            if (GetDbConnectionStatus()) // if connection open
            {
                SetDbConnectionStatus(false);
                Console.WriteLine("Oracle DB connection is closed.");
            }
            else // if connection not exists
                Console.WriteLine("No Oracle DB connection exists.");

        }
    }
}
