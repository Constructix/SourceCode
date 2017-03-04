using System;
using Test.Enums;

namespace Test
{
    public class Tariff : ITariff
    {
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public decimal Rate { get; set; }
        public TariffAccountType AccountType { get; set; }
        public TariffType TariffType { get; set; }
    }
}