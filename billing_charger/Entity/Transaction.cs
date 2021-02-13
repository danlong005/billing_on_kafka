using billing_charger.Entity.Charger;
using billing_charger.Models;

namespace billing_charger.Entity
{
    public class Transaction
    {
        public Collectible Collectible;
        public ChargerResponse ChargerResponse;

        public Transaction(Collectible collectible)
        {
            Collectible = collectible;
        }
    }
}