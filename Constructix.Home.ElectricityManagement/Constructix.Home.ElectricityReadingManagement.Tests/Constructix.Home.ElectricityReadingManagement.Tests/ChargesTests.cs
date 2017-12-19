using System;
using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Business.DomainModels.Charges;
using Xunit;

namespace Constructix.Home.ElectricityReadingManagement
{
    public class ChargesTests
    {
        private readonly List<SupplyCharge> charges;


        public ChargesTests()
        {
            charges = new List<SupplyCharge>
                {
                    new SupplyCharge(1.000m,  "Supply Charge", DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                    new SupplyCharge(0.0679m, "Metering Capital Charge", DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                    new SupplyCharge(0.0215m, "Metering Non Capital Charge", DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),
                    new SupplyCharge(0.003m,  "CL33 Capital Metering Charge", DateTime.Parse("01/07/2016"), DateTime.Parse("30/06/2017")),

                    new SupplyCharge(0.8957m, "Supply Charge", DateTime.Parse("01/07/2017")),
                    new SupplyCharge(0.0679m, "Metering Capital Charge", DateTime.Parse("01/07/2017")),
                    new SupplyCharge(0.0215m, "Metering Non Capital Charge", DateTime.Parse("01/07/2017")),
                    new SupplyCharge(0.0203m, "CL33 Capital Metering Charge", DateTime.Parse("01/07/2017"))
                };
        }

       [Fact]
        public void SupplyChargeInstanceNotNull()
        {
            decimal rate = .8957m;
            string description = "Supply Charge";
            ICharge supplyCharge = new SupplyCharge(rate, description, DateTime.Parse("01/07/2017"));
            Assert.NotNull(supplyCharge);
        }

        [Fact]
        public void CreateChargeLists()
        {
            var currentSupplyCharge =charges.FirstOrDefault(x => x.Description.Equals("Supply Charge") && !x.EffectiveTo.HasValue);

            if (currentSupplyCharge != null)
            {
                decimal expectedSupplyCharge = 0.8957m;
                Assert.Equal(currentSupplyCharge.Rate,expectedSupplyCharge,2);
            }
        }

        [Fact]
        public void MeteringNonCapital20162017Year()
        {
            var nonCapitalSupplyChargeExists = charges.Any(x =>
                x.Description.Contains("Metering Non Capital Charge") &&
                x.EffectiveFrom >= DateTime.Parse("01/01/2011") && x.EffectiveTo <= DateTime.Parse("30/06/2017"));

            Assert.True(nonCapitalSupplyChargeExists);
        }
    }
}