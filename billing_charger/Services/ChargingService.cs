using System;
using billing_charger.Entity;
using billing_charger.Models;

namespace billing_charger.Services
{
    public class ChargingService
    {
       public enum ChargingStatus
        {
            DECLINED, 
            APPROVED,
            TIMED_OUT
        }
        
        public ChargingResponse Charge(Subscription subscription)
        {
            ChargingResponse chargingResponse = null;
            
            int resp = this.runCharge(subscription);
            switch(resp)
            {
                case (int) ChargingStatus.APPROVED:
                    chargingResponse = new ApprovedChargingResponse();
                    break;
                
                case (int) ChargingStatus.TIMED_OUT:
                    chargingResponse = new TimedoutChargingResponse();
                    break;
                
                default:
                    chargingResponse = new DeclinedChargingResponse();
                    break;
            }

            return chargingResponse;
        }

        private int runCharge(Subscription subscription)
        {
            Random random = new Random();
            int randomNumber = random.Next();
            int status;
            
            if (randomNumber / 2 == 0)
            {
                status = (int) ChargingStatus.APPROVED;
            }
            else
            {
                status = (int) ChargingStatus.DECLINED;
            }

            return status;
        }
    }
}