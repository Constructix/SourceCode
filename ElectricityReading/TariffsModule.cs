using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ConsoleApp1.Tariffs.Implementators;
using ConsoleApp1.Tariffs.Interface;

namespace ConsoleApp1
{
    internal class TariffsModule
    {
        public static void Run()
        {
            var tariffs = InitialiseTariffs();


            PrintTariffs(tariffs);
        }

        private static List<ITariff> InitialiseTariffs()
        {
            List<ITariff> tariffs = new List<ITariff>();
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

        static void PrintTariffs(List<ITariff> tariffs)
        {
            const string TARIFF_DETAILS = "Tariff Details";
            const char LINE = '-';
            Console.WriteLine(TARIFF_DETAILS);
            Console.WriteLine(new String(LINE, 80));
            Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", Header.Tariff.Rate, Header.Tariff.EffectiveFrom, Header.Tariff.EffectiveTo, Header.Tariff.Name);

            foreach (ITariff tariff in tariffs)
            {
                Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", tariff.Rate, tariff.EffectiveFrom.ToShortDateString(), tariff.EffectiveTo.GetValueOrDefault().ToShortDateString(), tariff.ToString());
            }
        }

    }

    public static class Header
    {
        public static class Tariff
        {
            public const string Rate = "Rate";
            public const string EffectiveFrom = "Effective From";
            public const string EffectiveTo = "Effective To";
            public const string Name = "Tariff";
        }
    }
}