using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constructix.Home.Electricity;
using Constructix.Home.Electricity.Calculators;
using Constructix.Home.Electricity.Tariffs.Implementators;
using Constructix.Home.Electricity.Validators;
using Xunit;
using Xunit.Abstractions;

namespace ElectricityReadingTests.Tariffs
{
    public class TariffTests
    {
        private ITestOutputHelper _consoleHelper;

        public TariffTests(ITestOutputHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }
        [Fact]
        public void GetAllDebitTariffs()
        {
            List<BaseTariff> debitTariffs = new List<BaseTariff>
            {
                new ElectricityTariff(.2461m, DateTime.Parse("01/01/2017"), 
                                                DateTime.Parse("30/06/2017"), false),
                new ElectricityTariff(.26m, DateTime.Parse("01/07/2017"),null, false)
            };

            var lastReading = new Reading(37660, DateTime.Parse("16/06/2017"));
            var newReading = new Reading(38820, DateTime.Parse("14/09/2017"));

            var result = new ReadingCalculator(new ReadingValidator()).CalculatedUsage(lastReading, newReading);


            int totalUsage = result.TotalUsage;

            _consoleHelper.WriteLine($"Total Usage: { totalUsage}");
            
            // print out out tariffs

            debitTariffs.ForEach(x=> _consoleHelper.WriteLine(x.Rate.ToString()));
        }
}

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
