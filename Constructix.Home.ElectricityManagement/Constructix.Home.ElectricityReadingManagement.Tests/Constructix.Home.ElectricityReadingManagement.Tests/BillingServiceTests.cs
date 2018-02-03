using System;
using System.Collections.Generic;
using Constructix.Home.Electricity.Business.DomainModels;
using Constructix.Home.Electricity.Business.DomainModels.Charges;
using Constructix.Home.Electricity.Business.DomainModels.Readings;
using Constructix.Home.Electricity.Business.DomainModels.Services;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors;
using Xunit;

namespace Constructix.Home.ElectricityReadingManagement
{
    public class BillingServiceTests
    {
        private readonly List<BaseTariff> _tariffs = new List<BaseTariff>();
        private readonly List<SupplyCharge> _charges = new List<SupplyCharge>();


        public BillingServiceTests()
        {
            _tariffs = new List<BaseTariff>
            {
                new ElectricityTariff(0.2461m, DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                new ElectricityTariff(0.26m, DateTime.Parse("01/07/2017"), null),
                new  HotWaterTarff(0.1696m, DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                new  HotWaterTarff(0.1696m, DateTime.Parse("01/07/2016"), null),
            };

            _charges = new List<SupplyCharge>
            {
                new SupplyCharge(1.00m, "Supply Charge", DateTime.Parse("01/07/2017")),
                new SupplyCharge(.03m, "CL33 Supply Charge", DateTime.Parse("01/07/2017")),
                new SupplyCharge(1.07m, "Solar Metering Service Charge", DateTime.Parse("01/07/2017"))
            };
        }


        [Fact]
        public void BillingService_CreateElectricityTotal()
        {
            Reading previousReading = new Reading(1000, DateTime.Parse("01/10/2016"), TariffType.Electricity);
            Reading latestReading = new Reading(1200, DateTime.Parse("01/03/2017"), TariffType.Electricity);

            Reading hotwaterPreviousReading = new Reading(2344, DateTime.Parse("01/10/2016"), TariffType.HotWater);
            Reading hotwaterLatestReading = new Reading(2544, DateTime.Parse("01/03/2017"), TariffType.HotWater);



            Meter electricityMeter = new Meter("12345678", previousReading, latestReading);
            Meter hotWaterMeter  =  new Meter("65443432", hotwaterPreviousReading, hotwaterLatestReading);
            
            

            var tariffSvc  =new TariffService(_tariffs);

            var chargeServices = new ChargeService(_charges);
            BillingService billingSvc = new BillingService(tariffSvc, chargeServices);
            //billingSvc.Create()


        }
    }
}