using System;
using Constructix.Home.ElectricityReadingManagement.Models;
using Constructix.Home.ElectricityReadingManagement.Utilities;

namespace Constructix.Home.ElectricityReadingManagement.Services
{
    public class ReadingCalculatorService
    {
        public static ReadingResult CalculateReadings(Reading previousReading, Reading latestReading)
        {

            if(!previousReading.TariffType.Name.Equals(latestReading.TariffType.Name))
                throw new Exception("Readings have different Tariff types assigned.");

            return new ReadingResult(UsageForPeriod(previousReading, latestReading), TotalDays(previousReading, latestReading));
        }
        private static int UsageForPeriod(Reading previousReading, Reading latestReading)
        {
            if (!previousReading.TariffType.Name.Equals(latestReading.TariffType.Name))
                throw new Exception("Readings have different Tariff types assigned.");
            return Reading.CalculateUsage(previousReading, latestReading);
        }

        private static int TotalDays(Reading previousReading, Reading latestReading)
        {
            if (!previousReading.TariffType.Name.Equals(latestReading.TariffType.Name))
                throw new Exception("Readings have different Tariff types assigned.");

            return latestReading.Recorded.Subtract(previousReading.Recorded).Days + 1;
        }
    }
}