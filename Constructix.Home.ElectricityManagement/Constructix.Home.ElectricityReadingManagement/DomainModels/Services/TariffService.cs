using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Business.DomainModels.Readings;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors;

namespace Constructix.Home.Electricity.Business.DomainModels.Services
{
    public class TariffService
    {
        private readonly List<BaseTariff> _tariffs;
        public TariffService(List<BaseTariff> tariffs)
        {
            _tariffs = tariffs;
        }

        public List<BaseTariff> GetTariffs(Reading previousReading, Reading latestReading)
        {

            var tariffsInReadingPeriod = _tariffs.Where(t => t.Name.Equals(previousReading.TariffType.Name) && t.EffectiveFrom < previousReading.Recorded &&
                                                             t.EffectiveTo.GetValueOrDefault() >= previousReading.Recorded ||
                                                             (latestReading.Recorded > t.EffectiveFrom && !t.EffectiveTo.HasValue && t.Name.Equals(latestReading.TariffType.Name))).ToList();
            return tariffsInReadingPeriod;
        }
    }
}