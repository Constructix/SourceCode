using System;
using System.Collections.Generic;
using ConsoleApp1.Charges;

namespace ConsoleApp1
{
    public class ChargesManager
    {
        public static decimal CalculateCharges(int days)
        {
            var charges = InitialiseCharges();

            return charges.TotalCosts(days);
        }

        private static List<Charge> InitialiseCharges()
        {
            List<Charge> charges = new List<Charge>();
            // create some charges.

            charges.Add(new Charge("Metering Capital Charge", .8957m, DateTime.Parse("01/01/2017"), null));
            charges.Add(new Charge("Metering NonCapital Charge", .0215m, DateTime.Parse("01/01/2017"), null));
            charges.Add(new Charge("CL33 Capital Charge", .0203m, DateTime.Parse("01/01/2017"), null));
            charges.Add(new Charge("CLS NCapital Charge", .0064m, DateTime.Parse("01/01/2017"), null));
            return charges;
        }
    }
}