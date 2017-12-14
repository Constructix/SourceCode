using System;

namespace Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors
{
    public class HotWaterTarff : BaseTariff
    {
        public override  string Name => "HotWater";

        public HotWaterTarff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo) : base(rate, effectiveFrom, effectiveTo)
        {
        }
    }
}