using System;

namespace Constructix.Home.ElectricityReadingManagement.Models
{
    public class Reading
    {
        public Reading(int value, DateTime recordedOn, TariffType tariffType)
        {
            this.Value = value;
            this.Recorded = recordedOn;
            this.TariffType = tariffType;
        }

        public int Value { get; }
        public DateTime Recorded { get; }

        public TariffType TariffType { get;  }

        public static int CalculateUsage(Reading previousReading, Reading currentReading)
        {
            return currentReading.Value - previousReading.Value;
        }
    }
}
