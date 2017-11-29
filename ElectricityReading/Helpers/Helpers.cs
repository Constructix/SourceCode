using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Charges;

namespace Constructix.Home.Electricity.Helpers
{
    public static class Helpers
    {
        public static decimal TotalCosts(this List<Charge> charges, int numberOfDays)
        {
            return charges.Where(x=>x.IsDailyCharge).Sum(x => x.Rate * numberOfDays);
            
        }
    }
}