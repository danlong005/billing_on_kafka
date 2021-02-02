using System;
using System.Threading;
using billing_charger.Entity;
using billing_charger.Factories;
using billing_charger.Models;
using billing_charger.Services;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace billing_charger
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsumer<Ignore, string> consumer = KafkaConsumerFactory.Create();
            ChargingService chargingService = ChargingServiceFactory.Create();
            
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
                        Subscription subscription =
                            JsonConvert.DeserializeObject<Subscription>(consumeResult.Message.Value);
                        
                        /*
                         * TODO
                         * 
                         * if the subscription defines the chargingService then subscriptions
                         * could go to all different chargingService
                         * i.e. something like paypal that really just tells you when the
                         * charge failed you could queue to a charger that just approves
                         * and then the approval processor can make the entry in the GL. The
                         * paypal webhook would then dump into a decline queue to backout the GL
                         * entry and update the subscription
                         *
                         * Learn the resolver pattern to make this happen
                         */
                        ChargingResponse chargingResponse = chargingService.Charge(subscription);
                        
                        switch (chargingResponse.Status)
                        {
                            case ChargingService.ChargingStatus.APPROVED:
                                /*
                                 * TODO
                                 * 
                                 * using the resolver pattern we could determine what approvalProcessor
                                 * to run after the charge is approved. This would allow flexibility for
                                 * different billings(i.e. Associates/Memberships/Groups)
                                 */
                                break;
                            
                            case ChargingService.ChargingStatus.TIMED_OUT:
                                break;
                            
                            default:
                                // DECLINED
                                break;
                        }
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
    
