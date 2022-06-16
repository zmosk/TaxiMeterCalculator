using System;
using TaxiMeter.Common.Model;

namespace TaxiMeter.Services.Rules
{
    public class FastTravelRule : ITaxiFareRule
    {
        public decimal CalculateCharge(TaxiRide taxiRide)
        {
            return taxiRide.MinutesOver6Mph * .35m;
        }

        public string GetChargeType()
        {
            return "Fast Travel Surcharge";
        }
    }
}