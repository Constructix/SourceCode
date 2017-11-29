using System;

namespace Constructix.Home.Electricity.Tariffs.Implementators
{
    public class ElectricityTariff :  BaseTariff//ITariff
    {
        public ElectricityTariff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo, bool isDayCharge = false) : base(rate, effectiveFrom, effectiveTo, isDayCharge)
        {
            
        }
        public override string ToString() => this.GetType().Name.Substring(0,(this.GetType().Name.Length -  6));
    }
}