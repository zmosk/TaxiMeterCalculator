using System.Collections.Generic;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.Rules;

namespace TaxiMeter.Services.CalculatorService
{
    public interface ICalculatorService
    {
        public decimal CalculateFare(TaxiRide taxiRide);
    }
}
