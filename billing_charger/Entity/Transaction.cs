using billing_charger.Entity.Charger;
using billing_charger.Models;

namespace billing_charger.Entity
{
    public class Transaction
    {
        public Subscription Subscription;
        public ChargerResponse ChargerResponse;

        public Transaction(Subscription subscription)
        {
            Subscription = subscription;
        }
    }
}