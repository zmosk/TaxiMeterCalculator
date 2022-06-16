using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMeter.Common.Model;
using TaxiMeter.Services.Rules;

namespace TaxiMeter.Services.Test.Rules
{
    [TestClass]
    class InitialChargeRuleTest
    {
        [TestMethod]
        public void InitialChargeRuleShouldReturn3()
        {
            var initialChargeRule = new EntryChargeRule();
            var taxiFare = new TaxiRide();

            var actualCharge = initialChargeRule.CalculateCharge(taxiFare);

            var expectedCharge = 3m;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

    }
}
