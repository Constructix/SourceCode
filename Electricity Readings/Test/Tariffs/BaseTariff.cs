using System;

namespace Test
{
    public enum TariffAccountType
    {
        Debit,
        Credit
    }

    public enum TariffType
    {
        Electricity,
        Hotwater,
        Solar
    }

    public abstract class  BaseTariff 
    {
        public DateTime EffectiveFrom  { get; set; }
        public  DateTime? EffectiveTo { get; set; }
        public decimal Rate { get; set; }

        public TariffAccountType AccountType { get; set; }
    }

    public interface ITariff
    {
         DateTime EffectiveFrom { get; set; }
        DateTime? EffectiveTo { get; set; }
        decimal Rate { get; set; }

        TariffAccountType AccountType { get; set; }

        TariffType TariffType { get; set; }
    }
    public class Tariff : ITariff
    {
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public decimal Rate { get; set; }
        public TariffAccountType AccountType { get; set; }
        public TariffType TariffType { get; set; }
    }
}