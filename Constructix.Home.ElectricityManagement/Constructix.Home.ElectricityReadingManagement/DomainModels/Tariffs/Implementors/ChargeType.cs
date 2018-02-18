namespace Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors
{
    public class ChargeType
    {
        public static ChargeType Day { get; } = new ChargeType();
        public static ChargeType Kwh { get; } = new ChargeType();


    }
}