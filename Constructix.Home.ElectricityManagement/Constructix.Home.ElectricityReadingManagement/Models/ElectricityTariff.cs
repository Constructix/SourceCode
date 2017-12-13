using System;
using System.Runtime.Remoting.Messaging;

namespace Constructix.Home.ElectricityReadingManagement.Models
{
    public class ElectricityTariff : BaseTariff
    {

        public override string Name => "Electricity";
        

        public ElectricityTariff(decimal rate, DateTime effectiveFrom, DateTime? effectiveTo) : base(rate, effectiveFrom, effectiveTo)
        {
            
        }
    }
}