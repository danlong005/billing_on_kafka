using billing_producer.Models;
using Npgsql;

namespace billing_producer.Mappers
{
    public static class CollectibleMapper
    {
        public static Collectible ToCollectible(NpgsqlDataReader reader)
        {
            Collectible collectible = new Collectible();
            collectible.Id = reader.GetInt64(0);
            collectible.AmountDue = reader.GetDecimal(1);
            collectible.DueDay = reader.GetInt32(2);
            collectible.PaidTo = reader.GetDateTime(3);
            collectible.ApprovalQueuer = reader.GetString(4);
            collectible.DeclinedQueuer = reader.GetString(5);
            collectible.TimedoutQueuer = reader.GetString(6);
            collectible.PaymentMethodId = reader.GetInt64(7);
            
            return collectible;
        }
    }
}