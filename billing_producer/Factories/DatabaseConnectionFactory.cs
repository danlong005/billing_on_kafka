using Npgsql;

namespace billing_producer.Factories
{
    public class DatabaseConnectionFactory
    {
        private static NpgsqlConnection connection;
        
        public static NpgsqlConnection create()
        {
            string connectionString = "Host=postgres;Username=postgres;Password=postgres;Database=subscriptions";
            if (connection != null)
            {
                return connection;
            }
            else
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }
    }
}