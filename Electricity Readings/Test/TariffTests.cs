using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Test
{

    public class ElectricityCalculatorTests
    {
        [Fact]
        public void ElectricityCalculatorCalc()
        {
            var tariffs = ElectricityTestHelper.LoadTariffCollection();

            var firstReading = new Reading {Value = 1000, RecordedOn = DateTime.Parse("01/03/2017")};
            var secondReading = new Reading {Value = 2000, RecordedOn = DateTime.Now};

            var usage = Reading.CalculateUsage(firstReading, secondReading);

            var totalUsage =   ElectricityCalculator.Calculate(usage, ElectricityTestHelper.GetCurrent().Rate);


            Assert.Equal(totalUsage, 12.5m);

            Console.WriteLine(totalUsage);

        }
    }


    public class TariffTests
    {
        [Fact]
        public void TariffRateIsNotZero()
        {
            ITariff tariff = new ElectricityTariff();
            Assert.NotNull(tariff);
        }

        [Fact]
        public void EffectiveFromIsNotNull()
        {
            ITariff tariff = new ElectricityTariff() {EffectiveFrom = DateTime.Parse("01/06/2016")};

            Assert.NotNull(tariff.EffectiveFrom);
        }

        [Fact]
        public void EffectiveToIsNull()
        {
            ITariff tariff = new ElectricityTariff() {EffectiveTo = null};
            Assert.Null(tariff.EffectiveTo);
        }

        [Fact]
        public void RateIsGreaterThanZeroExpectedValue()
        {
            decimal expectedRate = 0.189m;

            ITariff tariff = new ElectricityTariff() {Rate = 0.189m};
            Assert.Equal(tariff.Rate, expectedRate);
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
            decimal amount = 100.00m;
            int totalUsage = 100;
            decimal rate = 0.0125m;
            decimal usage = ElectricityCalculator.Calculate(totalUsage, rate);
            Assert.Equal(usage,1.25m );
        }
    }
}