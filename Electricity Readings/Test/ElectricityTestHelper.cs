using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public static class ElectricityTestHelper
    {


        public static ITariff GetCurrent()
        {
            var tariffs = LoadTariffCollection();
            return tariffs.FirstOrDefault(x => !x.EffectiveTo.HasValue);
        }

        public static List<ITariff> LoadTariffCollection()
        {
            List<ITariff> tariffs = new List<ITariff>()
            {
                new ElectricityTariff
                {
                    EffectiveFrom = DateTime.Parse("01/01/2016"),
                    EffectiveTo = DateTime.Parse("30/06/2016"),
                    Rate = 0.0189m
                },
                new ElectricityTariff
                {
                    EffectiveFrom = DateTime.Parse("01/07/2016"),
                    EffectiveTo = DateTime.Parse("31/12/2016"),
                    Rate = 0.0120m
                },
                new ElectricityTariff
                {
                    EffectiveFrom = DateTime.Parse("01/07/2016"),
                    Rate = 0.0125m
                }
            };
            return tariffs;
        }
    }
}