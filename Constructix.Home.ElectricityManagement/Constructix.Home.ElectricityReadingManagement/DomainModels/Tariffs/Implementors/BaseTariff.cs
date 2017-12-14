using System;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Interfaces;

namespace Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors
{
    public abstract class BaseTariff : ITariff
    {
        
        public virtual string Name => "Base";
        public decimal Rate { get; }
        public DateTime EffectiveFrom { get; }
        public DateTime? EffectiveTo { get; }

        public BaseTariff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo)
        {
            Rate = rate;
            EffectiveFrom = effectiveFrom;
            EffectiveTo = effectiveTo;
        }
    }
}