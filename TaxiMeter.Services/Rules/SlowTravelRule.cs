using TaxiMeter.Common.Model;

namespace TaxiMeter.Services.Rules
{
    public class SlowTravelRule : ITaxiFareRule
    {
        public decimal CalculateCharge(TaxiRide taxiRide)
        {
            return (taxiRide.MilesUnder6Mph / .2m) * .35m;
        }

        public string GetChargeType()
        {
            return "Slow Travel Charge";
        }
    }
}
