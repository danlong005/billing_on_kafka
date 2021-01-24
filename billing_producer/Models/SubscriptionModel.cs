using System;

namespace billing_producer.Models
{
    public class Subscription
    {
        public long Id;
        public decimal AmountDue;
        public int DueDay;
        public DateTime PaidTo;
    }
}