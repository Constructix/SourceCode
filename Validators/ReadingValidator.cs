public class ReadingValidator : IValidator
{
    public bool IsValid(Reading firstReading, Reading secondReading) => (secondReading.Value >= firstReading.Value);
    
}