using billing_charger.Services;

namespace billing_charger.Entity
{
    public class TimedoutChargingResponse : ChargingResponse
    {
        public TimedoutChargingResponse()
        {
            this.Status = ChargingService.ChargingStatus.TIMED_OUT;
        }
    }
}