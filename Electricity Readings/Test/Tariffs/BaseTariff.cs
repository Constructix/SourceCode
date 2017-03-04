using System;
using Test.Enums;

namespace Test
{
    public abstract class  BaseTariff 
    {
        public DateTime EffectiveFrom  { get; set; }
        public  DateTime? EffectiveTo { get; set; }
        public decimal Rate { get; set; }

        public TariffAccountType AccountType { get; set; }
    }
}