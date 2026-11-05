using System.Data.SqlClient;

namespace RetailSalesSystem.DAL
{
    public class DBConnect
    {
        protected SqlConnection connection;
        protected string connString = @"Server=localhost;Database=SalesDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DBConnect()
        {
            connection = new SqlConnection(connString);
        }

        protected void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        protected void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}