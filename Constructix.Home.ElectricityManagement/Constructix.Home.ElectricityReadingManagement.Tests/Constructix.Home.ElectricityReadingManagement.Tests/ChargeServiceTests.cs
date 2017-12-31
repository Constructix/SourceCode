using System;
using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Business.DomainModels.Charges;
using Constructix.Home.Electricity.Business.DomainModels.Services;
using Xunit;

namespace Constructix.Home.ElectricityReadingManagement
{
    public class ChargeServiceTests
    {

        private List<SupplyCharge> _charges;

        public ChargeServiceTests()
        {
            InitialiseCharges();
        }

        [Fact]
        public void CreateChargeServicesNoExceptionExpected()
        {
            ChargeService chargeSvc  = new ChargeService(_charges);
            Assert.NotNull(chargeSvc);
        }

        private void InitialiseCharges()
        {
            _charges = new List<SupplyCharge>
            {
                new SupplyCharge(1.000m, "Supply Charge", DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                new SupplyCharge(0.0679m, "Metering Capital Charge", DateTime.Parse("01/07/2017"),
                    DateTime.Parse("30/06/2017")),
                new SupplyCharge(0.003m, "CL33 Capital Metering Charge", DateTime.Parse("01/07/2017"),
                    DateTime.Parse("30/06/2017")),

                new SupplyCharge(0.8957m, "Supply Charge", DateTime.Parse("01/07/2017")),
                new SupplyCharge(0.0679m, "Metering Capital Charge", DateTime.Parse("01/07/2017")),
                new SupplyCharge(0.0215m, "Metering Non Capital Charge", DateTime.Parse("01/07/2017")),
                new SupplyCharge(0.0203m, "CL33 Capital Metering Charge", DateTime.Parse("01/07/2017"))
            };
        }

        [Fact]
        public void GetCurrentSupplyChargeReturns8957AsExpected()
        {
            var currentSupplyCharge  = new ChargeService(_charges).GetLatestChange("Supply Charge");
            Assert.NotNull(currentSupplyCharge);
        }


        [Fact]
        public void GetSupplyChargeFor2016()
        {
            var supplyChargeFor2016 = new ChargeService(_charges).GetCharges("Supply Charge",DateTime.Parse("01/07/2016"),DateTime.Parse("30/06/2017"));

            Assert.True(supplyChargeFor2016.Any());
        }

    }
}