using System.Collections.Generic;
using billing_producer.Factories;
using billing_producer.Mappers;
using billing_producer.Models;
using Npgsql;

namespace billing_producer.Repositories
{
    public class CollectibleRepository
    {
        private NpgsqlConnection connection;

        public CollectibleRepository()
        {
            connection = DatabaseConnectionFactory.create();
        }

        public List<Collectible> findAll()
        {
            List<Collectible> Collectibles = new List<Collectible>();
            
            string sqlCommand = $"SELECT * " +
                                $"FROM collectibles";
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommand, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Collectibles.Add(CollectibleMapper.ToCollectible(reader));
            }

            return Collectibles;
        }
    }
}