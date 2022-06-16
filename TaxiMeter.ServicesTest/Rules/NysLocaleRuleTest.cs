using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.Rules;

namespace TaxiMeter.Services.Test.Rules
{
    [TestClass]
    public class NysLocaleRuleTest
    {
        [TestMethod]
        public void NysLocaleRuleShouldAlwaysReturn50Cents()
        {
            var peakRule = new NysLocaleRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 2, 17, 0, 0), // Thursday 5:00 pm
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = .50m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }
    }
}
