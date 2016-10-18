using System;

namespace SubmitOrders
{
    public static class SharePriceExtensions
    {
        public static DateTime ToDateTimeFromCsvDateTime(this string ComSecSharePriceDateTime)
        {
            int year, month, day;

            int.TryParse(ComSecSharePriceDateTime.Substring(0, 2), out year);
            int.TryParse(ComSecSharePriceDateTime.Substring(2, 2), out month);
            int.TryParse(ComSecSharePriceDateTime.Substring(4, 2), out day);

            if (year < 30)
                year += 2000;


            return new DateTime(year, month, day);
        }
    }
}