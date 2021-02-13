using billing_charger.Queuers.Declines;

namespace billing_charger.Factories
{
    public static class DeclinedQueuerFactory
    {
        private static SimpleDeclinedQueuer _simpleDeclinedQueuer;

        public static IDeclinedQueuer Create(string declinedCallbackQueuer)
        {
            switch (declinedCallbackQueuer.ToUpper())
            {
                case "SIMPLE":
                    return CreateSimpleDeclinedCallbackQueuer();
                    break;
                
                default:
                    return CreateSimpleDeclinedCallbackQueuer();
                    break;
            }
        }

        private static IDeclinedQueuer CreateSimpleDeclinedCallbackQueuer()
        {
            if (_simpleDeclinedQueuer == null)
            {
                _simpleDeclinedQueuer = new SimpleDeclinedQueuer();
            }

            return _simpleDeclinedQueuer;
        }
    }
}