using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Charges;

namespace ConsoleApp1
{
    public static class Helpers
    {
        public static decimal TotalCosts(this List<Charge> charges, int numberOfDays)
        {
            return charges.Where(x=>x.IsDailyCharge).Sum(x => x.Rate * numberOfDays);
            
        }
    }
}