using Test.Enums;

namespace Test
{
    public class ElectricityTariff : BaseTariff
    {
        public ElectricityTariff()
        {
            AccountType = TariffAccountType.Debit;
        }

    }
}