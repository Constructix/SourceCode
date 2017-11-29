namespace Constructix.Home.Electricity.Validators
{
    public interface IValidator
    {
        bool IsValid(Reading firstReading, Reading secondReading);
    }
}