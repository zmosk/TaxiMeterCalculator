using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.Rules;
using Calc = TaxiMeter.Services.CalculatorService;

namespace TaxiMeter.Services.Test.CalculatorServiceTests
{

    [TestClass]
    public class CalculatorServiceTest
    {
        Mock<ILogger<Calc.CalculatorService>> _loggerMock;
        Calc.CalculatorService _calculatorService;
        List<ITaxiFareRule> _rules;
        Mock<ITaxiFareRule> _mockRule1;
        Mock<ITaxiFareRule> _mockRule2;
        Mock<ITaxiFareRule> _mockRule3;

        [TestInitialize]
        public void Init()
        {
            _loggerMock = new Mock<ILogger<Calc.CalculatorService>>();
            _mockRule1 = new Mock<ITaxiFareRule>();
            _mockRule2 = new Mock<ITaxiFareRule>();
            _mockRule3 = new Mock<ITaxiFareRule>();

            _rules = new List<ITaxiFareRule> { _mockRule1.Object, _mockRule2.Object, _mockRule3.Object };
            
            _calculatorService = new Calc.CalculatorService(_rules, _loggerMock.Object);

            _mockRule1.Setup(x => x.CalculateCharge(It.IsAny<TaxiRide>())).Returns(1);
            _mockRule2.Setup(x => x.CalculateCharge(It.IsAny<TaxiRide>())).Returns(2);
            _mockRule3.Setup(x => x.CalculateCharge(It.IsAny<TaxiRide>())).Returns(3);
        }

        [TestMethod]
        public void CalculateFareShouldThrowExceptionIfTaxiRideIsNull()
        {
            Action action = () => _calculatorService.CalculateFare(null);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void CalculateFareShouldReturnFareWhenRunningRules()
        {
            var taxiRide = new TaxiRide
            {
                StartOfRide = new DateTime(2022, 6, 9, 10, 0, 0)
            };

            var fare = _calculatorService.CalculateFare(taxiRide);

            Assert.IsTrue(fare > 0);
        }

        [TestMethod]
        public void CalculateFareShouldReturnCombinedChargesWhenRunningRules()
        {
            var taxiRide = new TaxiRide
            {
                StartOfRide = new DateTime(2022, 6, 9, 10, 0, 0)
            };

            var actualFare = _calculatorService.CalculateFare(taxiRide);
            var expectedFare = 6;

            Assert.AreEqual(expectedFare, actualFare);
        }

        [TestMethod]
        public void CalculateFareShouldThrowExceptionIfRuleThrowsException()
        {
            var taxiRide = new TaxiRide
            {
                StartOfRide = new DateTime(2022, 6, 9, 10, 0, 0)
            };

            // Rule3 will throw an exception
            _mockRule3.Setup(x => x.CalculateCharge(It.IsAny<TaxiRide>())).Throws<Exception>();

            Action action = () => _calculatorService.CalculateFare(taxiRide);

            Assert.ThrowsException<Exception>(action);
        }


    }
}
