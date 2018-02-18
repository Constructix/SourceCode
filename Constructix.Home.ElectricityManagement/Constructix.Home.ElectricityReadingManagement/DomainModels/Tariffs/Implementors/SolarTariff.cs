using System;
using System.Collections.Generic;

namespace Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors
{
    public class SolarTariff : BaseTariff
    {
        public override string Name => "Solar";

        public SolarTariff(ChargeType chargeType, decimal rate, DateTime effectiveFrom, DateTime? effectiveTo) : base(chargeType, rate, effectiveFrom, effectiveTo)
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