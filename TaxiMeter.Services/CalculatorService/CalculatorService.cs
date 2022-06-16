using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.Rules;

namespace TaxiMeter.Services.CalculatorService
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ILogger Logger;
        private IEnumerable<ITaxiFareRule> Rules { get; set; }

        public CalculatorService(IEnumerable<ITaxiFareRule> rules, ILogger<CalculatorService> logger)
        {
            Rules = rules;
            Logger = logger;
        }
        public decimal CalculateFare(TaxiRide taxiRide)
        {
            if (taxiRide == null)
                throw new ArgumentNullException(nameof(taxiRide));

            try
            {
                var totalFare = 0m;

                Logger.LogInformation($"------- Taxi Fare Details: -------");

                foreach (var rule in Rules)
                {
                    var charge = rule.CalculateCharge(taxiRide);
                    totalFare += charge;

                    Logger.LogInformation($"{rule.GetChargeType()}: ${charge}");
                    Logger.LogInformation($"Total fare is ${totalFare}");
                }

                return totalFare;
            }
            catch (Exception e)
            {
                // Throwing error here instead of returning possible partial fare, which is wrong and may not be noticed.
                Logger.LogError(e, $"An error has occurred in {nameof(CalculateFare)}");
                throw;
            }
        }
    }
}
