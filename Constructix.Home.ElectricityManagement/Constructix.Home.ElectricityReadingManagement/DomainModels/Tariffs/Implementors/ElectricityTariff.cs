using System;

namespace Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors
{
    public class ElectricityTariff : BaseTariff
    {

        public override string Name => "Electricity";
        

        public ElectricityTariff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo) : base(rate, effectiveFrom, effectiveTo)
        {
            
        }
    }
}