using System;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Interfaces;
using Xunit;

namespace Constructix.Home.ElectricityReadingManagement.Old_Tests
{
    public class TariffCharges
    {
        [Fact]
        public void NotNull()
        {
            ITariff newTariff = new ElectricityTariff(ChargeType.Kwh,  0.2461m,
                                                    DateTime.Parse("01/07/2016"), 
                                                    DateTime.Parse("30/06/2017"));
        }
    }
}