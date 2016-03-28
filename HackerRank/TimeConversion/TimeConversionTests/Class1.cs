using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TimeConversionTests
{
    [TestFixture]
    public class TimeConversionTests
    {
        ITimeConverter _converter;
        [SetUp]
        public void Setup()
        {
            _converter = new TimeConverter();
        }
        [Test]
        public void InputValidTime()
        {
          
            Assert.That(_converter != null);
            Assert.That(_converter.GetType() == typeof(TimeConverter));
        }

        [Test]
        public void InputValidTimeReturnsValidString()
        {

            string expectedResult = "15:00:00";
            
            string converted24HourTime =  _converter.Convert("03:00PM");
            Assert.That(converted24HourTime.Equals(expectedResult));
        }

        //[Test]
        //public void InputInValidTimeRaisesExeception()
        //{
            
        //    Assert.That(()=> _converter.Convert("ABCD"), Throws.TypeOf<Exception>());
        //}

        [Test]
        public void InputValidTimeReturnsCorrectHour()
        {
            string expectedResult = "15";
            string returnedResult = _converter.Convert("3:00:00PM");
            Assert.That(returnedResult.Substring(0,2).Equals(expectedResult));
        }

        [Test]
        public void InputValidTimeWithMinuteReturnsCorrectHour()
        {
            string expectedHourResult = "19";
            string expectedMinutResult = "05";
            string returnedResult = _converter.Convert("7:05:00PM");
            Assert.That(returnedResult.Substring(0, 2).Equals(expectedHourResult));
            Assert.That(returnedResult.Substring(3, 2).Equals(expectedMinutResult));
            Console.WriteLine(returnedResult);
        }

        [Test]
        public void InputValidTimeWithSecondReturnsCorrectHour()
        {
            string expectedHourResult = "19";
            string expectedMinutResult = "05";
            string expectedSecondResult = "45";
            string returnedResult = _converter.Convert("7:05:45PM");
            Assert.That(returnedResult.Substring(0, 2).Equals(expectedHourResult));
            Assert.That(returnedResult.Substring(3, 2).Equals(expectedMinutResult));
            Assert.That(returnedResult.Substring(6, 2).Equals(expectedSecondResult));
            Console.WriteLine(returnedResult);
        }

        [Test]
        public void InputMidNightReturnsCorrectTime()
        {
            string expectedHourResult = "00";
            string expectedMinutResult = "00";
            string expectedSecondResult = "00";
            string returnedResult = _converter.Convert("12:00:00AM");
            Assert.That(returnedResult.Substring(0, 2).Equals(expectedHourResult));
            Assert.That(returnedResult.Substring(3, 2).Equals(expectedMinutResult));
            Assert.That(returnedResult.Substring(6, 2).Equals(expectedSecondResult));
            Console.WriteLine(returnedResult);
        }

        [Test]
        public void InputMidDayReturnsCorrectTime()
        {
            string expectedHourResult = "12";
            string expectedMinutResult = "00";
            string expectedSecondResult = "00";
            string returnedResult = _converter.Convert("12:00:00PM");
            Assert.That(returnedResult.Substring(0, 2).Equals(expectedHourResult));
            Assert.That(returnedResult.Substring(3, 2).Equals(expectedMinutResult));
            Assert.That(returnedResult.Substring(6, 2).Equals(expectedSecondResult));
            Console.WriteLine(returnedResult);
        }
        [Test]
        public void InputInvalid12HourTimeAsInputReturnsValid24HourTime()
        {
            string expectedHourResult = "13";
            string expectedMinutResult = "00";
            string expectedSecondResult = "00";


           
            string returnedResult = _converter.Convert("13:00:00PM");
            Assert.That(returnedResult.Substring(0, 2).Equals(expectedHourResult));
            Assert.That(returnedResult.Substring(3, 2).Equals(expectedMinutResult));
            Assert.That(returnedResult.Substring(6, 2).Equals(expectedSecondResult));
            Console.WriteLine(returnedResult);
        }
        //07:05:45PM
        [Test]
        public void InputTimeFromHackerRank()
        {
            string expectedResult = "19:05:45";
            string returnedResult = _converter.Convert("07:05:45PM");

            Assert.That(returnedResult.Equals(expectedResult));



        }


        [Test]
        public void InputInvalid24HourTimeAsInput()
        {
            Assert.That(() => _converter.Convert("25:00:00PM"), Throws.TypeOf<Exception>());
        }
        [Test]
        public void InputInvalidMinus24HourTimeAsInput()
        {
            Assert.That(() => _converter.Convert("-1:00:00PM"), Throws.TypeOf<Exception>());
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
                if(inputTimeAsDateTime.Hour <0 || inputTimeAsDateTime.Hour >23)
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

