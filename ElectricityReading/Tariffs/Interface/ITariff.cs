﻿using System;

namespace Constructix.Home.Electricity.Tariffs.Interface
{
    public interface ITariff
    {
        decimal Rate { get; }
        DateTime EffectiveFrom { get; }
        DateTime? EffectiveTo { get; }
        bool IsDayCharge { get; }
    }
}