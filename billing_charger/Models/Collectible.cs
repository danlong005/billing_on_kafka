using System;

namespace billing_charger.Models
{
    public class Collectible
    {
        public long Id;
        public decimal AmountDue;
        public int DueDay;
        public DateTime PaidTo;
        public string ApprovalQueuer;
        public string DeclinedQueuer;
        public string TimedoutQueuer;
        public long PaymentMethodId;
    }
}