using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.Rules;

namespace TaxiMeter.Services.Test.Rules
{
    [TestClass]
    public class FastTravelRuleTest
    {

        [TestMethod]
        public void FastTravelRuleShouldReturnNoUnitFareWhenNoTimeAbove6Mph()
        {
            var fastTravelRule = new FastTravelRule();
            var taxiRide = new TaxiRide
            {
                MinutesOver6Mph = 0
            };

            var actualCharge = fastTravelRule.CalculateCharge(taxiRide);

            var expectedCharge = 0m;

            Assert.AreEqual(actualCharge, expectedCharge);
        }

        [TestMethod]
        public void FastTravelRuleShouldReturn1UnitFareFor1MinuteAbove6Mph()
        {
            var fastTravelRule = new FastTravelRule();
            var taxiRide = new TaxiRide { 
                MinutesOver6Mph = 1
            };

            var actualCharge = fastTravelRule.CalculateCharge(taxiRide);

            var expectedCharge = .35m;

            Assert.AreEqual(actualCharge, expectedCharge);
        }

        [TestMethod]
        public void FastTravelRuleShouldReturn1UnitFareForEachMinuteAbove6Mph()
        {
            var fastTravelRule = new FastTravelRule();
            var taxiRide = new TaxiRide
            {
                MinutesOver6Mph = 10
            };

            var actualCharge = fastTravelRule.CalculateCharge(taxiRide);

            var expectedCharge = 3.50m;

            Assert.AreEqual(actualCharge, expectedCharge);
        }
    }
}
