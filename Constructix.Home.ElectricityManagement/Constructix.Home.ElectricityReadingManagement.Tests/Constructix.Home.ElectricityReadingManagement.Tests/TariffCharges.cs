using System;
using System.Collections.Generic;
using Constructix.Home.ElectricityReadingManagement.Models;
using Constructix.Home.ElectricityReadingManagement.Models.Interfaces;
using Xunit;

namespace Constructix.Home.ElectricityReadingManagement
{
    public class TariffCharges
    {
        [Fact]
        public void NotNull()
        {
            ITariff newTariff = new ElectricityTariff(0.2461m,
                                                    DateTime.Parse("01/07/2016"), 
                                                    DateTime.Parse("30/06/2017"));
        }
    }

    public class TariffRepository
    {
        

        IList<ITariff> ElectricityTariffs = new List<ITariff>();


        public TariffRepository(IList<ITariff> electricityTariffs)
        {
            
        }
    }
}