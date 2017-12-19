using System;

namespace Constructix.Home.Electricity.Business.DomainModels.Charges
{
    public class ICharge
    {
        public ICharge()
        {
        }

        public ICharge(decimal rate, string description, DateTime effectiveFrom, DateTime? effectiveTo)
        {
       
            Rate = rate;
            Description = description;
            EffectiveFrom = effectiveFrom;
            EffectiveTo = effectiveTo;
        }

       
        decimal Rate { get; }
        string Description { get; }
        DateTime EffectiveFrom { get; }
        DateTime? EffectiveTo { get; }

    }
}