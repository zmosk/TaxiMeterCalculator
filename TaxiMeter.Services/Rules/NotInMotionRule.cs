using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMeter.Common.Model;

namespace TaxiMeter.Services.Rules
{
    public class NotInMotionRule : ITaxiFareRule
    {
        public decimal CalculateCharge(TaxiRide taxiRide)
        {
            return 0m;
        }

        public string GetChargeType()
        {
            return "No Motion Charge";
        }
    }
}