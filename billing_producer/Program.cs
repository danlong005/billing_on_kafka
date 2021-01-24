using System;
using System.Collections.Generic;
using billing_producer.Models;
using billing_producer.Repositories;
using Npgsql;

namespace billing_producer
{
    class Program
    {
        private static SubscriptionRepository _subscriptionRepository = new SubscriptionRepository();
        
        static void Main(string[] args)
        {
            List<Subscription> subscriptions = _subscriptionRepository.findAll();

            foreach (Subscription sub in subscriptions)
            {
                Console.WriteLine(sub.Id);
            }
        }
    }
}
