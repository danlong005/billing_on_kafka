using System.Collections.Generic;
using billing_producer.Models;
using billing_producer.Repositories;
using Newtonsoft.Json;

namespace billing_producer
{
    class Program
    {
        private static CollectibleRepository _collectibleRepository = new CollectibleRepository();
        private static KafkaProducerRepository _kafkaRepository = new KafkaProducerRepository();
        
        static void Main(string[] args)
        {
            List<Collectible> collectibles = _collectibleRepository.findAll();
            foreach(Collectible collectible in collectibles) {
                _kafkaRepository.Create("billing", JsonConvert.SerializeObject(collectible));
            }
        }
    }
}
