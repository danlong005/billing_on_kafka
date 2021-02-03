using System;
using billing_charger.Entity;
using billing_charger.Entity.Charger;
using billing_charger.Models;

namespace billing_charger.Services.Chargers
{
    public class FakeChargerService : IChargerService
    {
        public ChargerResponse Charge(Subscription subscription)
        {
            ChargerResponse chargerResponse = null;
            
            int resp = this.runCharge(subscription);
            switch(resp)
            {
                case (int) ChargerStatus.APPROVED:
                    chargerResponse = new ApprovedChargerResponse();
                    break;
                
                case (int) ChargerStatus.TIMED_OUT:
                    chargerResponse = new TimedoutChargerResponse();
                    break;
                
                default:
                    chargerResponse = new DeclinedChargerResponse();
                    break;
            }

            return chargerResponse;
        }

        private int runCharge(Subscription subscription)
        {
            Random random = new Random();
            int randomNumber = random.Next();
            int status;
            
            if (randomNumber / 2 == 0)
            {
                status = (int) ChargerStatus.APPROVED;
            }
            else
            {
                status = (int) ChargerStatus.DECLINED;
            }

            return status;
        }
    }
}