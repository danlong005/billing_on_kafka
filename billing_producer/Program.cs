using System.Collections.Generic;
using billing_producer.Models;
using billing_producer.Repositories;
using Newtonsoft.Json;

namespace billing_producer
{
    class Program
    {
        private static SubscriptionRepository _subscriptionRepository = new SubscriptionRepository();
        private static KafkaProducerRepository _kafkaRepository = new KafkaProducerRepository();
        
        static void Main(string[] args)
        {
            List<Subscription> subscriptions = _subscriptionRepository.findAll();
            foreach(Subscription subscription in subscriptions) {
                _kafkaRepository.Create("billing", JsonConvert.SerializeObject(subscriptions));
            }
        }
    }
}
