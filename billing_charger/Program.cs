using System;
using System.Threading;
using Confluent.Kafka;

namespace billing_charger
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumerConfig config = new ConsumerConfig
            {   
                GroupId = "billing_charger",
                BootstrapServers = "kafka:9092"
            };
            
            IConsumer<Ignore, string> consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("billing");

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true; 
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    try
                    {
                        ConsumeResult<Ignore, string> consumeResult = consumer.Consume(cts.Token);
                        Console.WriteLine($"Message Received: {consumeResult.Message.Value}");
                        
                        /*
                         * Here we need to charge the payment
                         */

                        /*
                         * if approved put the subscription in the approved 
                         * queue.
                         */

                        /*
                         * if declined put the subscription in the declined queue
                         */

                    }
                    catch (ConsumeException ex)
                    {
                        Console.WriteLine($"Error Found: {ex.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException exception)
            {
                Console.WriteLine($"Error Found: {exception.Message}");
                consumer.Close();
            }
        }
    }
}
    
