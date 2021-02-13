using billing_charger.Entity;
using billing_charger.Entity.Charger;
using billing_charger.Models;

namespace billing_charger.Chargers
{
    public interface IChargerService
    {
        public ChargerResponse Charge(Collectible subscription);
    }
}