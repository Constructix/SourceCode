using System;

namespace VisualStudio2019Preview
{
    class Program
    {
        static void Main(string[] args)
        {
            var reading = new Reading(1000, DateTime.Parse("01/10/2018"));
            var secondReading = new Reading(2010, DateTime.Parse("17/12/2018"));

            Console.WriteLine(reading.DateTimeStamp.ToString());


            var svc = new ReadingCalculator();

            var days = svc.TotalDays(reading, secondReading);
            Console.WriteLine(days);

        }
    }

    public class ReadingCalculator
    {
        public int TotalUsage(Reading firstReading, Reading secondReading)
        {
            return secondReading.Value - firstReading.Value;
        }

        public int TotalDays(Reading firstReading, Reading secondReading)
        {

            return (int) (secondReading.DateTimeStamp - firstReading.DateTimeStamp).TotalDays;
            
        }
    }

    public class Reading
    {
        public int Value { get; }
        public DateTime DateTimeStamp { get; }
        public Reading()
        {

        }
        public Reading(int value, DateTime datetimeStamp)
        {
            this.Value = value;
            this.DateTimeStamp = datetimeStamp;
        }
        

    }
}
