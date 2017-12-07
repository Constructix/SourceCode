using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Tariffs.Implementators;

namespace Constructix.Home.Electricity.Services
{
    public class TariffService
    {
        private List<ElectricityTariff> _tariffs;
        public TariffService(List<ElectricityTariff> tariffs)
        {
            _tariffs = tariffs;
        }

        public List<ElectricityTariff> TariffsBetweenReadings(Reading previousReading, Reading latestReading)
        {

            var tariffsInReadingPeriod = _tariffs.Where(t => t.EffectiveFrom < previousReading.Recorded &&
                                                             t.EffectiveTo.GetValueOrDefault() >= previousReading.Recorded ||
                                                             (latestReading.Recorded > t.EffectiveFrom && !t.EffectiveTo.HasValue)).ToList();
            return tariffsInReadingPeriod;
        }
    }
}