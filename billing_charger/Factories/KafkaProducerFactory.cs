using Confluent.Kafka;

namespace billing_charger.Factories
{
    public class KafkaProducerFactory
    {
        private static IProducer<Null, string> producer;

        public static IProducer<Null, string> Create()
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = "kafka:9092"
            };

            if (producer == null)
            {
                producer = new ProducerBuilder<Null, string>(config).Build();
            }

            return producer;
        }
    }
}