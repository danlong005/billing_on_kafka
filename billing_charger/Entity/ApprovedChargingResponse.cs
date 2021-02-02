using billing_charger.Services;

namespace billing_charger.Entity
{
    public class ApprovedChargingResponse : ChargingResponse
    {
        public ApprovedChargingResponse()
        {
            base.Status = ChargingService.ChargingStatus.APPROVED;
        }
    }
}