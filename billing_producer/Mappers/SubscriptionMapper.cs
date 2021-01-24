using billing_producer.Models;
using Npgsql;

namespace billing_producer.Mappers
{
    public static class SubscriptionMapper
    {
        public static Subscription ToSubscription(NpgsqlDataReader reader)
        {
            Subscription sub = new Subscription();
            sub.Id = reader.GetInt64(0);
            sub.AmountDue = reader.GetDecimal(1);
            sub.DueDay = reader.GetInt32(2);
            sub.PaidTo = reader.GetDateTime(3);
            
            return sub;
        }
    }
}