using System;

namespace Constructix.Extensions.Samples.Demo
{
    public static  class LegacyExtensions
    {

        public static string ToLegacyFormat(this DateTime dateTime)
        {
            return dateTime.Year > 1930 ? dateTime.ToString("1yyMMdd") : dateTime.ToString("0yyMMdd");
        }


        public static string ToLegacyFromat(this string name)
        {
            var parts = name.ToUpper().Split(' ');
            return $"{parts[1]}, {parts[0]}";
        }

    }
}