using System.Collections.Generic;
using billing_producer.Factories;
using billing_producer.Mappers;
using billing_producer.Models;
using Npgsql;

namespace billing_producer.Repositories
{
    public class SubscriptionRepository
    {
        private NpgsqlConnection connection;

        public SubscriptionRepository()
        {
            connection = DatabaseConnectionFactory.create();
        }

        public List<Subscription> findAll()
        {
            List<Subscription> Subscriptions = new List<Subscription>();
            
            string sqlCommand = $"SELECT * " +
                                $"FROM subscriptions";
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommand, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Subscriptions.Add(SubscriptionMapper.ToSubscription(reader));
            }

            return Subscriptions;
        }
    }
}