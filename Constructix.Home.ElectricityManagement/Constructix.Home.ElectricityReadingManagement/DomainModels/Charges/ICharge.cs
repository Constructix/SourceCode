using System;

namespace Constructix.Home.Electricity.Business.DomainModels.Charges
{
    public interface ICharge
    {
        decimal Rate { get; }
        string Description { get; }
        DateTime EffectiveFrom { get; }
        DateTime? EffectiveTo { get; }

    }
}