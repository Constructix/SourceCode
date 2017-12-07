using System;
using System.Text;
using System.Threading.Tasks;

namespace Constructix.Home.Electricity.Services
{
    public class ReadingCalculatorService
    {
        public static Domain_Models.ReadingResult CalculateReadings(Reading previousReading, Reading latestReading)
        {
            return new Domain_Models.ReadingResult(UsageForPeriod(previousReading, latestReading), TotalDays(previousReading, latestReading));
        }
        private static int UsageForPeriod(Reading previousReading, Reading latestReading)
        {
            return Reading.Subtract(previousReading, latestReading);
        }

        private static int TotalDays(Reading previousReading, Reading latestReading)
        {
            return latestReading.Recorded.Subtract(previousReading.Recorded).Days;
        }
    }
}
