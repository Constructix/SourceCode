using Test.Enums;

namespace Test.Interfaces
{
    public class ElectricitySupplyCharge : IChargeRate
    {
        public ChargeType ChargeType { get; set; }
        public decimal Rate { get; set; }
    }
}