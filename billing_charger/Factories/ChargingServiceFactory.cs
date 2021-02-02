using billing_charger.Services;

namespace billing_charger.Factories
{
    public static class ChargingServiceFactory
    {
        private static ChargingService _chargingService;
        
        public static ChargingService Create()
        {
            if (_chargingService == null)
            {
                _chargingService = new ChargingService();
            }

            return _chargingService;
        } 
    }
}