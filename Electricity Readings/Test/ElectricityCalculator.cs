using System;

namespace Test
{
    public static class ElectricityCalculator
    {
        public static decimal Calculate(int totalUsage, decimal rate)
        {
            return (decimal) totalUsage * rate;
        }

        internal static decimal Calculate(CalculatorData data)
        {
            return Calculate(data.TotalUsage, data.Tariff.Rate);
        }
    }


    public class CalculatorData
    {
        public int TotalUsage { get; set; }
        public BaseTariff Tariff { get; set; }  
    }
}