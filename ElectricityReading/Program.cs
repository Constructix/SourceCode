﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Charges;

namespace ConsoleApp1
{

    public static class Helpers
    {
        public static decimal TotalCosts(this List<Charge> charges, int numberOfDays)
        {
            var total = charges.Sum(x => x.Rate * numberOfDays);
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var electricityMeter = new ElectricityMeter();

            // create readings
            AddReadings(electricityMeter);
            var readingValidator = new ReadingValidator();
            var calculator = new ReadingCalculator(readingValidator);

            // Now using electricity
            Console.WriteLine("Electricity Readings");

            var firstReading = electricityMeter.Readings.First();
            var lastestReading = electricityMeter.Readings.Last();

            var readingResult = calculator.CalculatedUsage(firstReading, lastestReading);
            Console.WriteLine(readingResult.TotalUsage);
            

            TestResult(calculator, electricityMeter);
            TariffsModule.Run();



            var charges = new List<Charge> { new Charge("Metering Capital Charge", .8957m, DateTime.Parse("01/01/2017"), null)};

            var total = charges.Sum(x => x.Rate * 90);

            Console.WriteLine(total.ToString("c"));

            var total2 = charges.TotalCosts(90);

            Console.WriteLine(total2);


        }

        private static void AddReadings(ElectricityMeter electricityMeter)
        {
            var reading = new Reading(1000, DateTime.Today.Date.AddDays(-10));
            var secondReading = new Reading(1010, DateTime.Today.Date.AddDays(-9));

            electricityMeter.Readings.Add(reading);
            electricityMeter.Readings.Add(secondReading);

            electricityMeter.Readings.Add(new Reading(1020, DateTime.Today.Date.AddDays(-8)));
            electricityMeter.Readings.Add(new Reading(1025, DateTime.Today.Date.AddDays(-7)));
            electricityMeter.Readings.Add(new Reading(1030, DateTime.Today.Date.AddDays(-7)));
            
        }

        private static void TestResult(ReadingCalculator calculator, ElectricityMeter meter )
        {
           

            var firstReading = meter.Readings.First();
            var secondReading = meter.Readings.Last();

            var readingResult = calculator.CalculatedUsage(firstReading, secondReading);

            PrintReadingResultProperties(readingResult);
            var message = "Now Assigning invalid values to reading objects, result should be IsValid = false";
            message.Dump();

            firstReading = new Reading(2000, DateTime.Today.Date.AddDays(-1));
            secondReading = new Reading(1000, DateTime.Today);

            readingResult = calculator.CalculatedUsage(firstReading, secondReading);
            PrintReadingResultProperties(readingResult);
        }

        private static void PrintReadingResultProperties(ReadingResult readingResult)
        {
            readingResult.Isvalid.Dump();
            readingResult.TotalUsage.Dump();
            readingResult.CalcualatedOn.Dump();
        }
    }


    public interface IMeter
    {
        List<Reading> Readings { get; set; }
    }

    public abstract class BaseMeter : IMeter
    {
        protected List<Reading> _readings;

        public List<Reading> Readings
        {
            get { return _readings; }
            set { _readings = value; }
        }


        public BaseMeter()
        {
            Readings = new List<Reading>();
        }
    }

  

    public class ElectricityMeter : BaseMeter
    {
    }
}

public static class ExtenstionHelpers
{
    public static void Dump<T>(this T instance)
    {
         Console.WriteLine(instance);
    }
}

// Define other methods and classes here