using System;
using Constructix.Home.Electricity.Business.DomainModels.Readings;

namespace Constructix.Home.Electricity.Business.DomainModels.Services
{


    public static class Constants
    {
        public static class ReadingCalculatorService
        {
            public const string READINGS_DIFFERENT_TYPES_ASSIGNED = "Readings have different Tariff types assigned.";
        }
    }
    public class ReadingCalculatorService
    {
        public static ReadingResult CalculateReadings(Reading previousReading, Reading latestReading)
        {

            if(!previousReading.TariffType.Name.Equals(latestReading.TariffType.Name))
                throw new Exception(Constants.ReadingCalculatorService.READINGS_DIFFERENT_TYPES_ASSIGNED);

            return new ReadingResult(UsageForPeriod(previousReading, latestReading), TotalDays(previousReading, latestReading));
        }
        private static int UsageForPeriod(Reading previousReading, Reading latestReading)
        {
            if (!previousReading.TariffType.Name.Equals(latestReading.TariffType.Name))
                throw new Exception(Constants.ReadingCalculatorService.READINGS_DIFFERENT_TYPES_ASSIGNED);
            return Reading.CalculateUsage(previousReading, latestReading);
        }

        private static int TotalDays(Reading previousReading, Reading latestReading)
        {
            if (!previousReading.TariffType.Name.Equals(latestReading.TariffType.Name))
                throw new Exception(Constants.ReadingCalculatorService.READINGS_DIFFERENT_TYPES_ASSIGNED);

            return latestReading.Recorded.Subtract(previousReading.Recorded).Days + 1;
        }
    }
}