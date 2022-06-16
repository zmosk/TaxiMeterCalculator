using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.Rules;

namespace TaxiMeter.Services.Test.Rules
{
    [TestClass]
    public class NightTimeRuleTest
    {
        [TestMethod]
        public void NightTimeRuleShouldReturnSurchargeWhenRideIsAfter8Pm()
        {
            var nightTimeRule = new NightTimeRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 2, 20, 0, 0) // Thursday 8:00 pm
            };

            var actualCharge = nightTimeRule.CalculateCharge(taxiRide);

            var expectedCharge = .50m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void NightTimeRuleShouldReturnSurchargeWhenRideIsBefore6Am()
        {
            var nightTimeRule = new NightTimeRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 2, 5, 59, 59) // Thursday 5:59 am
            };

            var actualCharge = nightTimeRule.CalculateCharge(taxiRide);

            var expectedCharge = .50m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void NightTimeRuleShouldNotReturnSurchargeWhenRideIsBefore8Pm()
        {
            var nightTimeRule = new NightTimeRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 2, 19, 59, 59) // Thursday 7:59 pm
            };

            var actualCharge = nightTimeRule.CalculateCharge(taxiRide);

            var expectedCharge = 0m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void NightTimeRuleShouldNotReturnSurchargeWhenRideIsAfter6Am()
        {
            var nightTimeRule = new NightTimeRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 2, 6, 01, 00) // Thursday 6:01 am
            };

            var actualCharge = nightTimeRule.CalculateCharge(taxiRide);

            var expectedCharge = 0m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void NightTimeRuleShouldApplySurchargeOnSaturday()
        {
            var nightTimeRule = new NightTimeRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 4, 1, 0, 0) // Saturday 1:00 am
            };

            var actualCharge = nightTimeRule.CalculateCharge(taxiRide);

            var expectedCharge = .50m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void NightTimeRuleShouldApplySurchargeOnSunday()
        {
            var nightTimeRule = new NightTimeRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 5, 1, 0, 0) // Sunday 1:00 am
            };

            var actualCharge = nightTimeRule.CalculateCharge(taxiRide);

            var expectedCharge = .50m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }
    }
}
