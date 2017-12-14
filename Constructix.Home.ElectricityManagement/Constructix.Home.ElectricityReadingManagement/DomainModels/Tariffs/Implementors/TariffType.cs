using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors
{
    public class TariffType
    {

        public static TariffType Electricity { get; } = new TariffType(0, "Electricity");
        public static TariffType HotWater { get; } = new TariffType(1, "HotWater");
        public static TariffType Solar { get; } = new TariffType(2, "Solar");


        public string Name { get; private set; }
        public int Value { get; private set; }


        private TariffType(int val, string name)
        {
            this.Value = val;
            this.Name = name;
        }


        public static IEnumerable<TariffType> List()
        {
            return new[] { Electricity, HotWater, Solar };
        }

        public static TariffType FromString(string tariffTypeString)
        {
            return List().Single(l => string.Equals(l.Name, tariffTypeString, StringComparison.OrdinalIgnoreCase));
        }

        public static TariffType FromValue(int value)
        {
            return List().Single(l => l.Value == value);
        }
    }
}