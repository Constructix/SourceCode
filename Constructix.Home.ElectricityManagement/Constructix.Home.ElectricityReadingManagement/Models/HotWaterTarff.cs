using System;

namespace Constructix.Home.ElectricityReadingManagement.Models
{
    public class HotWaterTarff : BaseTariff
    {
        public override  string Name => "HotWater";

        public HotWaterTarff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo) : base(rate, effectiveFrom, effectiveTo)
        {
        }
    }
}