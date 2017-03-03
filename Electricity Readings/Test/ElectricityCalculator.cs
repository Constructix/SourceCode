namespace Test
{
    public static class ElectricityCalculator
    {
        public static decimal Calculate(int totalUsage, decimal rate)
        {
            return (decimal) totalUsage * rate;
        }
    }
}