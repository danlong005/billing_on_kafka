using System.Collections.Generic;
using billing_producer.Models;
using billing_producer.Repositories;
using Confluent.Kafka;

namespace billing_producer
{
    class Program
    {
        private static SubscriptionRepository _subscriptionRepository = new SubscriptionRepository();
        
        static void Main(string[] args)
        {
            List<Subscription> subscriptions = _subscriptionRepository.findAll();
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = "kafka:9092",
                ClientId = "The_Producer"
            };
            
            var producer = new ProducerBuilder<Null, string>(config).Build();
            Message<Null, string> message = new Message<Null, string> {Value = $"TEST_MESSAGE"};
            producer.Produce("billing", message);
        }
    }
}
