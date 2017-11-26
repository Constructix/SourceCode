public interface IValidator
{
    bool IsValid(Reading firstReading, Reading secondReading);
}