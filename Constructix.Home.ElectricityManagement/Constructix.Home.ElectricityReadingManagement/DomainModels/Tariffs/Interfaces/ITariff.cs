using System;

namespace Constructix.Home.Electricity.Business.DomainModels.Tariffs.Interfaces
{
    public interface ITariff
    {

        
        string Name { get; }
        decimal Rate { get; }
        DateTime EffectiveFrom { get; }
        DateTime? EffectiveTo { get; }

       
    }
}