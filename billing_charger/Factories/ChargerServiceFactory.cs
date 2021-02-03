using billing_charger.Services.Chargers;

namespace billing_charger.Factories
{
    public static class ChargerServiceFactory
    {
        private static FakeChargerService _fakeChargerService;
        
        public static IChargerService Create(string charger)
        {
            switch (charger.ToUpper())
            {
                case "FAKE":
                    return CreateFakeChargerService();
                    break;
                
                default:
                    return CreateFakeChargerService();
                    break;
            }
        }

        private static IChargerService CreateFakeChargerService()
        {
            if (_fakeChargerService == null)
            {
                _fakeChargerService = new FakeChargerService();
            }

            return _fakeChargerService;
        }
    }
}