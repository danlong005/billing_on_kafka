namespace billing_charger.Entity.Charger
{
    public class TimedoutChargerResponse : ChargerResponse
    {
        public TimedoutChargerResponse()
        {
            this.Status = ChargerStatus.TIMED_OUT;
        }
    }
}