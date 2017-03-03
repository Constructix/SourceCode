using System;

namespace Test
{
    public class ElectricityTariff : ITariff
    {
        public DateTime EffectiveFrom  { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public decimal Rate { get; set; }
    }
}