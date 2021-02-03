using billing_charger.Entity;
using billing_charger.Entity.Charger;
using billing_charger.Models;

namespace billing_charger.Queuers.Declines
{
    public interface IDeclinedQueuer
    {
        public bool queue(Transaction transaction);
    }
}