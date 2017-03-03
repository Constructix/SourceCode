using System;

namespace Test
{
    public interface ITariff
    {
        DateTime EffectiveFrom { get; set; }
        DateTime? EffectiveTo { get; set; }
        decimal Rate { get; set; }
    }
}