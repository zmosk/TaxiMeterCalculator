using TaxiMeter.Common.Model;

namespace TaxiMeter.Services.Rules
{
    public class EntryChargeRule : ITaxiFareRule
    {
        public decimal CalculateCharge(TaxiRide taxiRide)
        {
            return 3m;
        }

        public string GetChargeType()
        {
            return "Entry Charge";
        }
    }
}