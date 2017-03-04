using Test.Enums;
using Test.Interfaces;
using Xunit;

namespace Test
{
    public class ChargeRateTests
    {
        [Fact]
        public void ChargeRateInstanceNotNull()
        {
            IChargeRate electricitySupplyCharge = new ElectricitySupplyCharge();
            Assert.NotNull(electricitySupplyCharge);
        }

        [Fact]
        public void ChargeTypeIsDayRate()
        {
            IChargeRate chargeRate = new ElectricitySupplyCharge() {ChargeType = ChargeType.Day};
            Assert.True(chargeRate.ChargeType == ChargeType.Day);
        }

        [Fact]
        public void ChargeTypeIsKiloWattRate()
        {
            IChargeRate chargerRate = new ElectricitySupplyCharge {ChargeType = ChargeType.Kilowatt};
            Assert.True(chargerRate.ChargeType == ChargeType.Kilowatt);
        }

        [Fact]
        public void ChargeRateIsDecimal()
        {
            IChargeRate chargeRate = new ElectricitySupplyCharge() {Rate = .82m};
            Assert.True(chargeRate.Rate.Equals(.82m));
        }
    }
}