using System;

namespace ConsoleApp1.Tariffs.Interface
{
    public abstract class BaseTariff : ITariff
    {
        public decimal Rate { get; private set; }
        public DateTime EffectiveFrom { get; private set; }
        public DateTime? EffectiveTo { get; private set; }
        public bool IsDayCharge { get; private set; }

        public BaseTariff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo, bool isDayCharge)
        {
            this.Rate = rate;
            this.EffectiveFrom = effectiveFrom;
            this.EffectiveTo = effectiveTo;
            this.IsDayCharge = IsDayCharge;
        }
    }
}