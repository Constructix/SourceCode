using System;

namespace Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors
{
    public class HotWaterTarff : BaseTariff
    {
        public override  string Name => "HotWater";

        public HotWaterTarff(ChargeType chargeType, decimal rate, DateTime effectiveFrom, DateTime? effectiveTo) : base(chargeType, rate, effectiveFrom, effectiveTo)
        {
        }
    }
}