using System;
using Constructix.Home.Electricity.Tariffs.Interface;

namespace Constructix.Home.Electricity.Tariffs.Implementators
{
    public abstract class BaseTariff : ITariff
    {
        public decimal Rate { get; private set; }
        public DateTime EffectiveFrom { get; private set; }
        public DateTime? EffectiveTo { get; private set; }
        public bool IsDayCharge { get; private set; }
        


        protected BaseTariff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo, bool isDayCharge)
        {
            this.Rate = rate;
            this.EffectiveFrom = effectiveFrom;
            this.EffectiveTo = effectiveTo;
            this.IsDayCharge = IsDayCharge;


        }
    }
}