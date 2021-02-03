using billing_charger.Queuers.Approvals;

namespace billing_charger.Factories
{
    public static class ApprovalQueuerFactory
    {
        private static SimpleApprovalQueuer _simpleApprovalQueuer;

        public static IApprovalQueuer Create(string approvalCallbackService)
        {
            switch (approvalCallbackService.ToUpper())
            {
                case "SIMPLE":
                    return CreateSimpleApprovalCallbackService();
                    break;
                
                default:
                    return CreateSimpleApprovalCallbackService();
                    break;
            }
        }

        private static IApprovalQueuer CreateSimpleApprovalCallbackService()
        {
            if (_simpleApprovalQueuer == null)
            {
                _simpleApprovalQueuer = new SimpleApprovalQueuer();
            }

            return _simpleApprovalQueuer;
        }
    }
}