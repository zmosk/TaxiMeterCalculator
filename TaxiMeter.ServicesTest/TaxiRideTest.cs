using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaxiMeter.Common.Model;

namespace TaxiMeter.Services.Test
{
    [TestClass]
    public class TaxiRideTest
    {
        [TestMethod]
        public void TestMinutesUnder6Mph()
        {
            var taxiRide = new TaxiRide
            {
                MilesUnder6Mph = 10
            };

            var actualTime = taxiRide.MinutesUnder6Mph;
            var expectedTime = 200;

            Assert.AreEqual(expectedTime, actualTime);
        }

        [TestMethod]
        public void TestGetEndTimeOfTripWithMinutesOver6Mph()
        {
            var taxiRide = new TaxiRide
            {
                StartOfRide = new DateTime(2022, 6, 2, 19, 40, 0),
                //StartTimeOfRide = new TimeSpan(19, 40, 0),
                MinutesOver6Mph = 20
            };

            var actualTime = taxiRide.CalculateEndOfRide();

            var expectedTime = new DateTime(2022, 6, 2, 20, 0, 0);

            Assert.AreEqual(expectedTime, actualTime);
        }

        [TestMethod]
        public void TestGetEndTimeOfTripWithMilesUnder6Mph()
        {
            var taxiRide = new TaxiRide
            {
                StartOfRide = new DateTime(2022, 6, 2, 20, 0, 0),
                //StartTimeOfRide = new TimeSpan(20, 0, 0),
                MilesUnder6Mph = 1
            };

            var actualTime = taxiRide.CalculateEndOfRide();
            var expectedTime = new DateTime(2022, 6, 2, 20, 20, 0);

            Assert.AreEqual(expectedTime, actualTime);
        }

        [TestMethod]
        public void TestGetEndTimeOfTripWithMilesUnder6MphAndMinutesOver6Mph()
        {
            var taxiRide = new TaxiRide
            {
                StartOfRide = new DateTime(2022, 6, 2, 20, 0, 0),
                MinutesOver6Mph = 20,
                MilesUnder6Mph = 1
            };

            var actualTime = taxiRide.CalculateEndOfRide();
            var expectedTime = new DateTime(2022, 6, 2, 20, 40, 0);

            Assert.AreEqual(expectedTime, actualTime);
        }

    }
}
