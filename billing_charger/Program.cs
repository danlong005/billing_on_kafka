using System;
using System.Threading;
using billing_charger.Entity;
using billing_charger.Factories;
using billing_charger.Models;
using billing_charger.Queuers.Approvals;
using billing_charger.Queuers.Declines;
using billing_charger.Services.Chargers;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace billing_charger
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsumer<Ignore, string> consumer = KafkaConsumerFactory.Create();
            
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
                        
                        IChargerService chargerService = ChargerServiceFactory.Create(subscription.Charger);
                        Transaction transaction = new Transaction(subscription);
                        transaction.ChargerResponse = chargerService.Charge(transaction.Subscription);
                        
                        switch (transaction.ChargerResponse.Status)
                        {
                            case ChargerStatus.APPROVED:
                                IApprovalQueuer approvalQueuer =
                                    ApprovalQueuerFactory.Create(transaction.Subscription.ApprovalCallback);
                                approvalQueuer.queue(transaction);
                                break;
                            
                            case ChargerStatus.TIMED_OUT:
                                break;
                            
                            default:
                                // DECLINED
                                IDeclinedQueuer declinedQueuer =
                                    DeclinedQueuerFactory.Create(transaction.Subscription.DeclinedCallback);
                                declinedQueuer.queue(transaction);
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
    
