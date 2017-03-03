using System;

namespace Test
{


    public static class ReadingMessages
    {
        public const string SecondReadingLessMessage = "Second Reading cannot be < than first reading.";

    }

    public class Reading : IReading
    {
        public int Value { get; set; }
        public DateTime RecordedOn { get; set; }

        public static int CalculateUsage(Reading firstReading, Reading secondReading)
        {
            if(secondReading.Value < firstReading.Value)
                throw new Exception(ReadingMessages.SecondReadingLessMessage);
            return secondReading.Value - firstReading.Value;

        }
    }
}