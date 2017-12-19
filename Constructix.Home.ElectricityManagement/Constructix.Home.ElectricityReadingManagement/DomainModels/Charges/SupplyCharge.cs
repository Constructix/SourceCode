using System;

namespace Constructix.Home.Electricity.Business.DomainModels.Charges
{
    public class SupplyCharge : ICharge
    {
        public decimal Rate { get; }
        public string Description { get; }
        public DateTime EffectiveFrom { get; }
        public DateTime? EffectiveTo { get; }

        public SupplyCharge( decimal rate, string description, DateTime effectiveFrom, DateTime? effectiveTo = null) 
        {
            Rate = rate;
            Description = description;
            EffectiveFrom = effectiveFrom;
            EffectiveTo = effectiveTo;
        }
    }
}