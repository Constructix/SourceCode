using System;

namespace SubmitOrders
{
    class Helpers
    {
        public static bool DatesAreSame(DateTime firstDate, DateTime secondDate)
        {
            return firstDate.Year.Equals(secondDate.Year) && 
                   firstDate.Month.Equals(secondDate.Month) &&
                   firstDate.Day.Equals(secondDate.Day);
        }
    }
}