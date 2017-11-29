using System;
using System.Collections.Generic;
using Constructix.Home.Electricity.Tariffs.Implementators;

namespace Constructix.Home.Electricity
{
    internal class TariffsModule
    {
        public static void Run()
        {
            var tariffs = InitialiseTariffs();


            PrintTariffs(tariffs);
        }

        private static List<BaseTariff> InitialiseTariffs()
        {
            List<BaseTariff> tariffs = new List<BaseTariff>();
            decimal firstRate = 0.24m;
            var tariff = new ElectricityTariff(firstRate,
                DateTime.Parse("01/01/2017"),
                DateTime.Parse("30/06/2017"), false);
            tariffs.Add(tariff);
            tariffs.Add(new HotWaterTariff(.19m,
                DateTime.Parse("01/01/2017"),
                DateTime.Parse("30/06/2017")));

            tariffs.Add(new SolarTariff(rate: .52m,
                effectiveFrom: DateTime.Parse("01/01/2017"),
                effectiveTo: DateTime.Parse("30/06/2017"), isDayCharge: false));
            return tariffs;
        }

        static void PrintTariffs(List<BaseTariff> tariffs)
        {
            const string TARIFF_DETAILS = "Tariff Details";
            const char LINE = '-';
            Console.WriteLine(TARIFF_DETAILS);
            Console.WriteLine(new String(LINE, 80));
            Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", Header.Tariff.Rate, Header.Tariff.EffectiveFrom, Header.Tariff.EffectiveTo, Header.Tariff.Name);

            foreach (BaseTariff tariff in tariffs)
            {
                Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", tariff.Rate, tariff.EffectiveFrom.ToShortDateString(), tariff.EffectiveTo.GetValueOrDefault().ToShortDateString(), tariff.ToString());
            }
        }

    }
}