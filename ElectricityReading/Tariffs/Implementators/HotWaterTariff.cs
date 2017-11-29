using System;

namespace Constructix.Home.Electricity.Tariffs.Implementators
{
    public class HotWaterTariff : BaseTariff
    {

        public decimal Rate { get; private set; }
        public DateTime EffectiveFrom { get; private set; }
        public DateTime? EffectiveTo { get; private set; }
        public bool IsDayCharge { get; private set; }
        public HotWaterTariff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo, bool isDayCharge = false) : base(rate, effectiveFrom, effectiveTo, isDayCharge)
        {
        }

        public override string ToString() => this.GetType().Name.Substring(0, (this.GetType().Name.Length - 6));

    }
}