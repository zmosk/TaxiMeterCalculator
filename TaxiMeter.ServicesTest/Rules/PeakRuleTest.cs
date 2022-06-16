using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.Rules;

namespace TaxiMeter.Services.Test.Rules
{
    [TestClass]
    public class PeakRuleTest
    {
        [TestMethod]
        public void PeakRuleShouldReturnSurchargeWhenRideIsAfter4PmOnWeekday()
        {
            var peakRule = new PeakRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 2, 16, 0, 1) // Thursday 4:01 pm
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = 1m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void PeakRuleShouldReturnSurchargeWhenRideIsBefore8Pm()
        {
            var peakRule = new PeakRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 2, 19, 59, 59) // Thursday 7:59 pm
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = 1m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }


        [TestMethod]
        public void PeakRuleShouldReturnNoSurchargeWhenRideIsBefore4Pm()
        {
            var peakRule = new PeakRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 2, 15, 59, 59) // Thursday 3:59 pm
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = 0m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void PeakRuleShouldReturnNoSurchargeWhenRideIsAfter8Pm()
        {
            var peakRule = new PeakRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 2, 20, 01, 00) // Thursday 8:01 pm
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = 0m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void PeakRuleAfter8Pm()
        {
            var peakRule = new PeakRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new DateTime(2022, 6, 3, 20, 01, 00), // Friday 8:01 pm
                EndOfRide = new DateTime(2022, 6, 4, 0, 00, 00), // Saturday 12:00 am
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = 0m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void PeakRuleReturnsSurchargeWhenRideStartsOnWeekendAndEndsAfterPeak()
        {
            var peakRule = new PeakRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new DateTime(2022, 6, 6, 15, 59, 0), // Sunday 3:59 pm
                EndOfRide = new DateTime(2022, 6, 6, 16, 1, 0), // Monday 4:01 pm
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = 1m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }


        [TestMethod]
        public void PeakRuleShouldReturnNoSurchargeWhenRideIsOnSaturday()
        {
            var peakRule = new PeakRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 4, 17, 0, 0) // Saturday 5:00 pm
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = 0m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void PeakRuleShouldReturnSurchargeWhenRideIsOnSunday()
        {
            var peakRule = new PeakRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new System.DateTime(2022, 6, 5, 17, 0, 0) // Sunday 5:00 pm
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = 0m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [TestMethod]
        public void PeakRuleShouldReturnSurchargeWhenRideBeginsBeforePeakAndEndsDuringPeak()
        {
            var peakRule = new PeakRule();
            var taxiRide = new TaxiRide
            {
                StartOfRide = new DateTime(2022, 6, 2, 15, 0, 0), // Thursday 3:00 pm
                EndOfRide = new DateTime(2022, 6, 2, 16, 0, 0)
            };

            var actualCharge = peakRule.CalculateCharge(taxiRide);

            var expectedCharge = 1m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

    }
}
