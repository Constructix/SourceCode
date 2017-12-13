using System;

namespace Constructix.Home.ElectricityReadingManagement.Models.Interfaces
{
    public interface ITariff
    {

        
        string Name { get; }
        decimal Rate { get; }
        DateTime EffectiveFrom { get; }
        DateTime? EffectiveTo { get; }

       
    }
}