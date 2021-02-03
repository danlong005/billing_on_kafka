using billing_charger.Services;

namespace billing_charger.Entity.Charger
{
    public class DeclinedChargerResponse : ChargerResponse
    {
        public DeclinedChargerResponse()
        {
            base.Status = ChargerStatus.DECLINED;
        }
    }
}