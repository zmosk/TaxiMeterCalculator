using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.Rules;

namespace TaxiMeter.Services.Test.Rules
{
    [TestClass]
    public class SlowTravelRuleTest
    {
        [TestMethod]
        public void SlowTravelRuleShouldReturnNoUnitFareWhenNoTimeUnder6Mph()
        {
            var slowTravelRule = new SlowTravelRule();
            var taxiRide = new TaxiRide
            {
                MilesUnder6Mph = 0
            };

            var actualCharge = slowTravelRule.CalculateCharge(taxiRide);

            var expectedCharge = 0m;

            Assert.AreEqual(actualCharge, expectedCharge);
        }

        [TestMethod]
        public void SlowTravelRuleShouldReturn1UnitFareForOneFifthMileBelow6Mph()
        {
            var slowTravelRule = new SlowTravelRule();
            var taxiRide = new TaxiRide
            {
                MilesUnder6Mph = .2m
            };

            var actualCharge = slowTravelRule.CalculateCharge(taxiRide);

            var expectedCharge = .35m;

            Assert.AreEqual(actualCharge, expectedCharge);
        }

        [TestMethod]
        public void SlowTravelRuleShouldReturn1UnitFareForEachFifthMileBelow6Mph()
        {
            var slowTravelRule = new SlowTravelRule();
            var taxiRide = new TaxiRide
            {
                MilesUnder6Mph = 1
            };

            var actualCharge = slowTravelRule.CalculateCharge(taxiRide);

            var expectedCharge = 1.75m;

            Assert.AreEqual(actualCharge, expectedCharge);
        }
    }
}
