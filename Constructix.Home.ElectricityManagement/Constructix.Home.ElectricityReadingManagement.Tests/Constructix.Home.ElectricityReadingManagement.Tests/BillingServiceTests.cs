using System;
using System.Collections.Generic;
using Constructix.Home.Electricity.Business.DomainModels.Readings;
using Constructix.Home.Electricity.Business.DomainModels.Services;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors;
using Xunit;

namespace Constructix.Home.ElectricityReadingManagement
{
    public class BillingServiceTests
    {
        private readonly List<BaseTariff> _tariffs = new List<BaseTariff>();

        public BillingServiceTests()
        {
            _tariffs = new List<BaseTariff>
            {
                new ElectricityTariff(0.2461m, DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                new ElectricityTariff(0.26m, DateTime.Parse("01/07/2017"), null),
                new  HotWaterTarff(0.1696m, DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                new  HotWaterTarff(0.1696m, DateTime.Parse("01/07/2016"), null),
            };
        }
        [Fact]
        public void BillingService_CreateElectricityTotal()
        {
            Reading previousReading = new Reading(1000, DateTime.Parse("01/10/2016"), TariffType.Electricity);
            Reading latestReading = new Reading(1200, DateTime.Parse("01/03/2017"), TariffType.Electricity);




            var tariffSvc  =new TariffService(_tariffs);

            BillingService billingSvc = new BillingService(tariffSvc);




        }
    }
}