using System;
using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Business.DomainModels;
using Constructix.Home.Electricity.Business.DomainModels.Billing;
using Constructix.Home.Electricity.Business.DomainModels.Charges;
using Constructix.Home.Electricity.Business.DomainModels.Readings;
using Constructix.Home.Electricity.Business.DomainModels.Services;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Interfaces;
using Xunit;
using Xunit.Abstractions;

namespace Constructix.Home.ElectricityReadingManagement.Old_Tests
{

    public class BillingServiceTests
    {
        private List<BaseTariff> _tariffs;
        private readonly TariffService _tariffSvc;
        private readonly ChargeService _chargeService;

        public BillingServiceTests()
        {
            _tariffs = new List<BaseTariff>
            {
                new ElectricityTariff(ChargeType.Kwh,  0.26m, DateTime.Parse("01/07/2016"), null),
                new HotWaterTarff(ChargeType.Kwh,0.22m, DateTime.Parse("01/07/2017"), null),
                new SolarTariff(ChargeType.Kwh,0.546m,DateTime.Parse("01/07/2016"),null)
            };
            _tariffSvc = new TariffService(_tariffs);

           _chargeService = new ChargeService(new List<SupplyCharge>());
        }

        [Fact]
        public void InstanceNotNullNoExceptionExpected()
        {

          
            BillingService billingSvc = new BillingService(_tariffSvc, _chargeService );
            Assert.NotNull(billingSvc);
        }
    }

    public class Location
    {
        public Reading PreviousReading { get; set; }
        public Reading CurrentReading { get; set; }
    }


    public class ReadingCalculatorServiceTests
    {

        private ITestOutputHelper _helper;
        private Reading previousReading;
        private Reading currentReading;

        public ReadingCalculatorServiceTests(ITestOutputHelper helper)
        {
            _helper = helper;   
        }


        [Theory]
        [InlineData(1000, 1234, 234)]
        public void NotNull(int previousReadingValue, int currentReadingValue, int total)
        {
            previousReading = new Reading(previousReadingValue, DateTime.Today,TariffType.Electricity);
            currentReading = new Reading(currentReadingValue, DateTime.Today,TariffType.Electricity);
            
        }


        [Theory]
        [InlineData(38821, 40287)]

        public void Calculate(int previousReadingValue, int currentReadingValue)
        {
            previousReading = new Reading(previousReadingValue, DateTime.Today, TariffType.Electricity);
            currentReading = new Reading(currentReadingValue, DateTime.Today,TariffType.Electricity);

            var result = ReadingCalculatorService.CalculateReadings(previousReading, currentReading);

            ITariff newTariff = new ElectricityTariff(ChargeType.Kwh,  0.26m,
                DateTime.Parse("01/07/2016"),
                DateTime.Parse("30/06/2017"));

            decimal totalCost = newTariff.Rate * result.TotalUsage;

            _helper.WriteLine(totalCost.ToString());
            

        }


        [Theory]
        [InlineData(17513,17711)]

        public void CalculateHotWater(int previousReadingValue, int currentReadingValue)
        {
            previousReading = new Reading(previousReadingValue, DateTime.Today, TariffType.HotWater);
            currentReading = new Reading(currentReadingValue, DateTime.Today, TariffType.HotWater);

            var result = ReadingCalculatorService.CalculateReadings(previousReading, currentReading);
            // Assert.True(total.Equals(result.TotalUsage));


            ITariff newTariff = new ElectricityTariff(ChargeType.Kwh, 0.22m,
                DateTime.Parse("01/07/2017"), null);


            decimal totalCost = newTariff.Rate * result.TotalUsage;
            _helper.WriteLine($"Usage for period: {result.TotalUsage}");
            _helper.WriteLine($"Total HotWater: {totalCost.ToString("c")}");

        }

        [Theory]
        [InlineData(26743, 27779)]

        public void CalculateSolar(int previousReadingValue, int currentReadingValue)
        {
            previousReading = new Reading(previousReadingValue, DateTime.Today, TariffType.Solar);
            currentReading = new Reading(currentReadingValue, DateTime.Today, TariffType.Solar);

            var result = ReadingCalculatorService.CalculateReadings(previousReading, currentReading);
            // Assert.True(total.Equals(result.TotalUsage));


            ITariff newTariff = new ElectricityTariff(ChargeType.Kwh,  0.546m,DateTime.Parse("01/07/2016"),
                DateTime.Parse("30/06/2017"));


            decimal totalCost = newTariff.Rate * result.TotalUsage;


            _helper.WriteLine(totalCost.ToString());

            decimal credit = 288.66m;

            decimal Total = credit + totalCost;

            _helper.WriteLine($"Credit Total: { Total}");


        }


        [Theory]
        [InlineData(26743, 27779)]

        public void CalculateSupplyCharge(int previousReadingValue, int currentReadingValue)
        {
            previousReading = new Reading(previousReadingValue, DateTime.Parse("14/09/2017"),TariffType.Electricity);
            currentReading = new Reading(currentReadingValue, DateTime.Today, TariffType.Electricity);

            var result = ReadingCalculatorService.CalculateReadings(previousReading, currentReading);
            // Assert.True(total.Equals(result.TotalUsage));

             
            ITariff newTariff = new ElectricityTariff(ChargeType.Day,  1.00m, DateTime.Parse("01/07/2017"),null);


            decimal totalCost = result.TotalDays * newTariff.Rate;
            _helper.WriteLine(totalCost.ToString());
        }

        [Theory]
        [InlineData(26743, 27779)]

        public void CalculateSupplyCL33Charge(int previousReadingValue, int currentReadingValue)
        {
            previousReading = new Reading(previousReadingValue, DateTime.Parse("14/09/2017"), TariffType.Solar);
            currentReading = new Reading(currentReadingValue, DateTime.Today, TariffType.Solar);

            var result = ReadingCalculatorService.CalculateReadings(previousReading, currentReading);
            // Assert.True(total.Equals(result.TotalUsage));


            ITariff newTariff = new ElectricityTariff(ChargeType.Kwh,  .033m, DateTime.Parse("01/07/2017"), null);
            ITariff solarMeterCharge = new ElectricityTariff(ChargeType.Day,  0.07m, DateTime.Parse("01/07/2107"), null);

            decimal totalCost = result.TotalDays * newTariff.Rate;
            decimal totalSolarCharge = result.TotalDays * solarMeterCharge.Rate;

            _helper.WriteLine($"CL33 Charge: { totalCost}");
            _helper.WriteLine($"Solar Capital Charge: {totalSolarCharge}");
            _helper.WriteLine($"Total: {totalCost + totalSolarCharge}");
        }




    }
}