using Test.Enums;

namespace Test.Interfaces
{
    public interface IChargeRate
    {
        ChargeType ChargeType { get; set; }
        decimal Rate { get; set; }
        
    }
}