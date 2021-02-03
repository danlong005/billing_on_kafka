using billing_charger.Queuers.Declines;

namespace billing_charger.Factories
{
    public static class DeclinedQueuerFactory
    {
        private static SimpleDeclinedQueuer _simpleDeclinedQueuer;

        public static IDeclinedQueuer Create(string declinedCallbackService)
        {
            switch (declinedCallbackService.ToUpper())
            {
                case "SIMPLE":
                    return CreateSimpleDeclinedCallbackService();
                    break;
                
                default:
                    return CreateSimpleDeclinedCallbackService();
                    break;
            }
        }

        private static IDeclinedQueuer CreateSimpleDeclinedCallbackService()
        {
            if (_simpleDeclinedQueuer == null)
            {
                _simpleDeclinedQueuer = new SimpleDeclinedQueuer();
            }

            return _simpleDeclinedQueuer;
        }
    }
}