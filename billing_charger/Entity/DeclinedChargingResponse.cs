using billing_charger.Services;

namespace billing_charger.Entity
{
    public class DeclinedChargingResponse : ChargingResponse
    {
        public DeclinedChargingResponse()
        {
            base.Status = ChargingService.ChargingStatus.DECLINED;
        }
    }
}