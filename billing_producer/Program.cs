using System.Collections.Generic;
using billing_producer.Models;
using billing_producer.Repositories;
using Newtonsoft.Json;


namespace billing_producer
{
    class Program
    {
        private static SubscriptionRepository _subscriptionRepository = new SubscriptionRepository();
        private static KafkaRepository _kafkaRepository = new KafkaRepository();
        
        static void Main(string[] args)
        {
            List<Subscription> subscriptions = _subscriptionRepository.findAll();
            foreach(Subscription subscription in subscriptions) {
                _kafkaRepository.create("billing", JsonConvert.SerializeObject(subscriptions));
            }
        }
    }
}
