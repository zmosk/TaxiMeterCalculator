using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMeter.Common.Model;

namespace TaxiMeter.Services.Rules
{
    public class NightTimeRule : ITaxiFareRule
    {
        public decimal CalculateCharge(TaxiRide taxiRide)
        {
            // if trip started after 6AM and ended before 8PM, then no night surcharge is added
            if (taxiRide.StartOfRide >= taxiRide.StartOfRide.Date.AddHours(6)
                && taxiRide.EndOfRide < taxiRide.StartOfRide.Date.AddHours(20))
                return 0m;
                
            // else, trip either started before 6AM or ended after 8PM, therefore apply surcharge
            return .50m;
        }

        public string GetChargeType()
        {
            return "Nighttime Surcharge";
        }
    }
}