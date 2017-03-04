using System;
using System.Collections.Generic;
using System.Linq;
using Test.Enums;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class TariffTests
    {
        private readonly ITestOutputHelper _helper;

        public TariffTests(ITestOutputHelper helper)
        {
            _helper = helper;
        }


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

        [Fact]
        public void DecidingWhichIsBetterDeriveFromBaseTariffOrITariff()
        {


            var tariffs = new List<Tariff>()
            {
                new Tariff()
                {
                    TariffType = TariffType.Electricity,
                    AccountType = TariffAccountType.Debit,
                    Rate = 0.279m,
                    EffectiveFrom = DateTime.Parse("01/01/2016"),
                    EffectiveTo = DateTime.Parse("30/06/2016")
                },
                new Tariff()
                {
                    TariffType = TariffType.Hotwater,
                    AccountType = TariffAccountType.Debit,
                    Rate = 0.189m,
                    EffectiveFrom = DateTime.Parse("01/01/2016"),
                    EffectiveTo = DateTime.Parse("30/06/2016")
                },
                new Tariff()
                {
                    TariffType = TariffType.Solar,
                    AccountType = TariffAccountType.Credit,
                    Rate = 0.189m,
                    EffectiveFrom = DateTime.Parse("01/01/2016"),
                    EffectiveTo = DateTime.Parse("30/06/2016")
                },


            };


            var tariffGroups = tariffs.GroupBy(x => x.TariffType);

            _helper.WriteLine(tariffGroups.Count().ToString());

            foreach (IGrouping<TariffType, Tariff> tariffGroup in tariffGroups)
            {
                _helper.WriteLine(tariffGroup.Key.ToString());
                foreach (Tariff tariff in tariffGroup)
                {
                    _helper.WriteLine("\t" + tariff.Rate);
                }
            }

        }
    }
}