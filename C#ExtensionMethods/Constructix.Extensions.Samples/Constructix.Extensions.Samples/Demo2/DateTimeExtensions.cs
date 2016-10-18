using System;
using System.Xml;

namespace Constructix.Extensions.Samples.Demo2
{
    public static class DateTimeExtensions
    {
        public static string ToXmlDateTime(this DateTime dateTime)
        {
            return XmlConvert.ToString(dateTime, XmlDateTimeSerializationMode.Utc);
        }
        
    }
}