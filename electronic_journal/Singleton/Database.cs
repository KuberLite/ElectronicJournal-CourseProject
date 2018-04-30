using System.Configuration;
using System.Data.SqlClient;

namespace electronic_journal.Singleton
{
    public class Database
    {
        private static string connectionString;
        private static Database database;

        private SqlConnection connection;

        private Database()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public static Database GetInstance()
        {
            if (database == null)
            {
                database = new Database();
            }
            return database;
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public SqlDataAdapter ExequteQuery(string query)
        {
            return new SqlDataAdapter(query, connection);
        }
    }
}
