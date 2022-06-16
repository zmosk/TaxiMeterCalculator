using TaxiMeter.Common.Model;

namespace TaxiMeter.Services.Rules
{
    public interface ITaxiFareRule
    {
        public decimal CalculateCharge(TaxiRide taxiRide);
        public string GetChargeType();
    }
}
