namespace Constructix.Home.ElectricityReadingManagement.Utilities
{
    public class ReadingResult
    {
        public int TotalUsage { get; private set; }
        public int TotalDays { get; private set; }

        public ReadingResult(int totalUsage, int totalDays)
        {
            this.TotalUsage = totalUsage;
            this.TotalDays = totalDays;
        }

        public decimal AverageUsage()
        {
            return (decimal)TotalUsage / TotalDays;
        }

    }
}