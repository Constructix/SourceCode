using System;
using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Business.DomainModels.Readings;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors;
using Constructix.Home.ElectricityReadingManagement.Old_Tests;
using Xunit;
using TariffService = Constructix.Home.Electricity.Business.DomainModels.Services.TariffService;

namespace Constructix.Home.ElectricityReadingManagement
{
    public class TariffServiceTests
    {
        [Fact]
        public void TariffServiceReturnsTariffRates()
        {
            List<BaseTariff> baseTariffs = new List<BaseTariff>
            {
                new ElectricityTariff(ChargeType.Kwh,  0.2461m, DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                new ElectricityTariff(ChargeType.Kwh,  0.26m, DateTime.Parse("01/07/2017"), null),
                new  HotWaterTarff(ChargeType.Kwh,  0.1696m, DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                new  HotWaterTarff(ChargeType.Kwh, 0.1696m, DateTime.Parse("01/07/2016"), null),

            };

            Reading previousReading =  new Reading(1000, DateTime.Parse("01/10/2016"), TariffType.Electricity);
            Reading latestReading = new Reading(1200, DateTime.Parse("01/03/2017"), TariffType.Electricity);

            decimal expectedRate = 0.2461m;


            var tariffSvc = new TariffService(baseTariffs);
            var firstTariff =  tariffSvc.GetTariffs(previousReading, latestReading).Select(x => x.Rate);
            Assert.True(firstTariff.FirstOrDefault().Equals(expectedRate));
        }
    }
}