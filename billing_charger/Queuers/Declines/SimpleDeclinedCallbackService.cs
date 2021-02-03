using System;
using billing_charger.Entity;
using billing_charger.Repositories;
using Newtonsoft.Json;

namespace billing_charger.Queuers.Declines
{
    public class SimpleDeclinedQueuer : IDeclinedQueuer
    {
        public bool queue(Transaction transaction)
        {
            try
            {
                KafkaProducerRepository kafkaProducerRepository = new KafkaProducerRepository();
                kafkaProducerRepository.Create("decline_simple", JsonConvert.SerializeObject(transaction));

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception is: {ex.Message}");
                return false;
            }
        }
    }
}