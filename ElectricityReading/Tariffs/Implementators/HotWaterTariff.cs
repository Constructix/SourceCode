using System;
using ConsoleApp1.Tariffs.Interface;

namespace ConsoleApp1.Tariffs.Implementators
{
    public class HotWaterTariff : ITariff
    {

        public decimal Rate { get; private set; }
        public DateTime EffectiveFrom { get; private set; }
        public DateTime? EffectiveTo { get; private set; }
        public bool IsDayCharge { get; private set; }
        public HotWaterTariff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo, bool isDayCharge = false)
        {
            Rate = rate;
            EffectiveFrom = effectiveFrom;
            EffectiveTo = effectiveTo;
            this.IsDayCharge = isDayCharge;
        }

        public override string ToString() => this.GetType().Name.Substring(0, (this.GetType().Name.Length - 6));

    }
}