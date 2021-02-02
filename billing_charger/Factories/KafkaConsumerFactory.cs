using Confluent.Kafka;

namespace billing_charger.Factories
{
    public class KafkaConsumerFactory
    {
        private static IConsumer<Ignore, string> _consumer;
        
        public static IConsumer<Ignore, string> Create()
        {
            ConsumerConfig config = new ConsumerConfig
            {   
                GroupId = "billing_charger",
                BootstrapServers = "kafka:9092"
            };
            
            if (_consumer == null)
            {
                _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            }

            return _consumer;
        }
    }
}