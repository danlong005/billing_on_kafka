namespace billing_charger.Entity.Charger
{
    public class ApprovedChargerResponse : ChargerResponse
    {
        public ApprovedChargerResponse()
        {
            base.Status = ChargerStatus.APPROVED;
        }
    }
}