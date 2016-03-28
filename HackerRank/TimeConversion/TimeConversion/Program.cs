using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string time = Console.ReadLine();

            ITimeConverter converter = new TimeConverter();
            try
            {
                Console.WriteLine(converter.Convert(time));
            }
            catch (Exception ex)
            {
                
                Console.WriteLine( ex.Message);
            }
        }
    }

    public class TimeConverter : ITimeConverter
    {
        public string Convert(string inputTime)
        {
            DateTime inputTimeAsDateTime;
            if (!DateTime.TryParse(inputTime, out inputTimeAsDateTime))
            {
                throw new Exception("Input time is not Valid.Please enter in format: hh:mm:ssAM/PM");
            }
            else
            {
                if (inputTimeAsDateTime.Hour < 0 || inputTimeAsDateTime.Hour > 23)
                    throw new Exception("Input time is not Valid.Please enter in format: hh:mm:ssAM/PM");


                int hour = inputTimeAsDateTime.Hour;
                int minute = inputTimeAsDateTime.Minute;
                int seconds = inputTimeAsDateTime.Second;
                return $"{hour:00}:{minute:00}:{seconds:00}";
            }
        }
    }

    public interface ITimeConverter
    {
        string Convert(string inputTime);
    }
}
