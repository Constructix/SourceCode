using Test.Enums;

namespace Test
{
    public class SolarTariff : BaseTariff
    {
        public SolarTariff()
        {
            AccountType =  TariffAccountType.Credit;
        }
    }
}