using System;

namespace Test
{
    public enum TariffAccountType
    {
        Debit,
        Credit
    }

    public abstract class  BaseTariff 
    {
        public DateTime EffectiveFrom  { get; set; }
        public  DateTime? EffectiveTo { get; set; }
        public decimal Rate { get; set; }

        public TariffAccountType AccountType { get; set; }
    }
}