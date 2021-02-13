using System;
using System.Threading;
using billing_charger.Entity;
using billing_charger.Factories;
using billing_charger.Models;
using billing_charger.Queuers.Approvals;
using billing_charger.Queuers.Declines;
using billing_charger.Chargers;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace billing_charger
{
  class Program
  {
    static void Main(string[] args)
    {
      IConsumer<Ignore, string> consumer = KafkaConsumerFactory.Create();
      IChargerService chargerService = ChargerServiceFactory.Create();
      
      consumer.Subscribe("billing");

      CancellationTokenSource cts = new CancellationTokenSource();
      Console.CancelKeyPress += (_, e) =>
      {
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

            Console.WriteLine(consumeResult.Message.Value);
            
            Collectible collectible =
              JsonConvert.DeserializeObject<Collectible>(consumeResult.Message.Value);

            Console.WriteLine($"Collectible Approval Queuer: {collectible.ApprovalQueuer}");
            Console.WriteLine($"Collectible Declined Queuer: {collectible.DeclinedQueuer}");
            
            Transaction transaction = new Transaction(collectible);
            transaction.ChargerResponse = chargerService.Charge(transaction.Collectible);

            switch (transaction.ChargerResponse.Status)
            {
              case ChargerStatus.APPROVED:
                IApprovalQueuer approvalQueuer =
                  ApprovalQueuerFactory.Create(transaction.Collectible.ApprovalQueuer);
                approvalQueuer.queue(transaction);
                break;

              case ChargerStatus.TIMED_OUT:
                if (transaction.Collectible.TimedoutQueuer.Equals(""))
                {
                  // stuff right back in the billing queue
                }
                else
                {
                  // get the queuer and let it do it's work
                }

                break;

              case ChargerStatus.NON_COMPLETED:
                // DO NOTHING the charge response will come via a webhook later on
                break;

              default:
                // DECLINED
                IDeclinedQueuer declinedQueuer =
                  DeclinedQueuerFactory.Create(transaction.Collectible.DeclinedQueuer);
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