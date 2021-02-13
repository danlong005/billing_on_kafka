using billing_charger.Chargers;

namespace billing_charger.Factories
{
  public static class ChargerServiceFactory
  {
    private static ChargerService _chargerService;

    public static IChargerService Create()
    {
      if (_chargerService == null)
      {
        _chargerService = new ChargerService();
      }

      return _chargerService;
    }
  }
}