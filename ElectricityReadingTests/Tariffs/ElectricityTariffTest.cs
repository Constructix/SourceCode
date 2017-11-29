using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constructix.Home.Electricity.Tariffs.Implementators;
using Xunit;

namespace ElectricityReadingTests.Tariffs
{
    public class ElectricityTariffTest
    {
        private BaseTariff electricityTariff;
        public ElectricityTariffTest()
        {
            electricityTariff = new ElectricityTariff(.2461m, DateTime.Parse("01/01/2017"), null);
        }
        [Fact]
        public void InstanceCreatedNoExceptionExpected()
        {
            Assert.NotNull(electricityTariff);
        }

        [Fact]
        public void RateIsCorrectFromSetMethod()
        {
            decimal expectedValue = 0.2461m;

            Assert.True(electricityTariff.Rate.Equals(expectedValue));
        }

        [Fact]
        public void EffectiveFromIsNotNull()
        {
            DateTime expectedValue = DateTime.Parse("01/01/2017");
            Assert.True(electricityTariff.EffectiveFrom.Date.Equals(expectedValue));
        }

        [Fact]
        public void ChargeIsKilowatt()
        {
            bool expecteValue = false;   
            Assert.True(electricityTariff.IsDayCharge.Equals(expecteValue));
        }

        [Fact]
        public void EffectiveToNotSet()
        {
            Assert.Null(electricityTariff.EffectiveTo);
        }
    }
}
