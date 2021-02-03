using System;
using billing_producer.Factories;
using Confluent.Kafka;

namespace billing_producer.Repositories
{
    public class KafkaProducerRepository
    {
        private IProducer<Null, string> producer;

        public KafkaProducerRepository()
        {
            producer = KafkaProducerFactory.Create();
        }

        public void Create(string topic, string message)
        {
            Console.WriteLine(message);
            Message<Null, string> msg = new Message<Null, string>()
            {
                Value = message
            };
            producer.Produce(topic, msg);
            producer.Flush(TimeSpan.FromMilliseconds(500));
        }
    }
}