public class ReadingCalculator
{
    private const int ZERO = 0;
    private readonly IValidator _validator;
    public ReadingCalculator(IValidator validator)
    {
        this._validator = validator;
    }
    public ReadingResult CalculatedUsage(Reading firstReading, Reading lastReading)
    {

        var usage = ZERO;
        var isValid = _validator.IsValid(firstReading, lastReading);
        if(isValid)
            usage = lastReading.Value - firstReading.Value;
        return new ReadingResult(usage, isValid);
    }
}