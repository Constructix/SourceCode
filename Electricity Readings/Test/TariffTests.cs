using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class TariffTests
    {
        [Fact]
        public void TariffRateIsNotZero()
        {
            var tariff = new ElectricityTariff();
            Assert.NotNull(tariff);
        }

        [Fact]
        public void EffectiveFromIsNotNull()
        {
           BaseTariff baseTariff = new ElectricityTariff() {EffectiveFrom = DateTime.Parse("01/06/2016")};

            Assert.NotNull(baseTariff.EffectiveFrom);
        }

        [Fact]
        public void EffectiveToIsNull()
        {
           BaseTariff baseTariff = new ElectricityTariff() {EffectiveTo = null};
            Assert.Null(baseTariff.EffectiveTo);
        }

        [Fact]
        public void RateIsGreaterThanZeroExpectedValue()
        {
            decimal expectedRate = 0.189m;

           BaseTariff baseTariff = new ElectricityTariff() {Rate = 0.189m};
            Assert.Equal(baseTariff.Rate, expectedRate);
        }

        [Fact]
        public void RatesEffectiveToNullShouldBeReturnedAsExpected()
        {
            var tariffs = ElectricityTestHelper.LoadTariffCollection();

            decimal latestRate = 0.0125m;
            var firstOrDefault = tariffs.FirstOrDefault(x => !x.EffectiveTo.HasValue);
            if (firstOrDefault != null)
            {
                decimal latestTariffRate = firstOrDefault.Rate;
                Assert.Equal(latestRate, latestTariffRate);
            }
        }


        [Fact]
        public void UsageCalculation()
        {
            int totalUsage = 100;
            decimal rate = 0.0125m;
            decimal usage = ElectricityCalculator.Calculate(totalUsage, rate);
            Assert.Equal(usage,1.25m );
        }

        [Fact]
        public void UsageCalculatorCallingWithCalculatorData()
        {
            var reading1 = new Reading() {RecordedOn = DateTime.Now.AddDays(-1), Value = 1000};
            var reading2 = new Reading() {RecordedOn = DateTime.Now, Value = 1030};

            var currentTariff = ElectricityTestHelper.LoadTariffCollection().FirstOrDefault(x=>!x.EffectiveTo.HasValue);

            CalculatorData data = new CalculatorData() {Tariff = currentTariff, TotalUsage = Reading.CalculateUsage(reading1, reading2)};

            decimal electricityUsage = ElectricityCalculator.Calculate(data);

            //
            Assert.Equal(electricityUsage,0.375m );


        }
    }
}