using System;
using System.Collections.Generic;

namespace Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors
{
    public class SolarTariff : BaseTariff
    {
        public override string Name => "Solar";

        public SolarTariff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo) : base(rate, effectiveFrom, effectiveTo)
        {
        }
    }


    public class TariffManagement
    {
        public IEnumerable<string> List()
        {
            return new[] {"Electricity", "HotWater", "Solar"};
        }
    }
}