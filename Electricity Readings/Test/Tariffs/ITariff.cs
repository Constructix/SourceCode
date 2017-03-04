using System;
using Test.Enums;

namespace Test
{
    public interface ITariff
    {
        DateTime EffectiveFrom { get; set; }
        DateTime? EffectiveTo { get; set; }
        decimal Rate { get; set; }

        TariffAccountType AccountType { get; set; }

        TariffType TariffType { get; set; }
    }
}