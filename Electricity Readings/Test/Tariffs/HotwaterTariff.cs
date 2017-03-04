using Test.Enums;

namespace Test
{
    public class HotwaterTariff : BaseTariff
    {
        public HotwaterTariff()
        {
            AccountType = TariffAccountType.Debit;
        }
    }
}