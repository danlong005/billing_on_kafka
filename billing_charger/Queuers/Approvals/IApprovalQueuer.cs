using billing_charger.Entity;

namespace billing_charger.Queuers.Approvals
{
    public interface IApprovalQueuer
    {
        public bool queue(Transaction transaction);
    }
}