using System;
using TaxiMeter.Common.Model;

namespace TaxiMeter.Services.Rules
{
    public class NysLocaleRule : ITaxiFareRule
    {
        public decimal CalculateCharge(TaxiRide taxiRide)
        {
            return .50m;
        }

        public string GetChargeType()
        {
            return "New York State Surcharge";
        }
    }
}