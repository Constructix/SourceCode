using System;

namespace CsvWriter.Tests.DomainObjects
{
    public class Stock
    {
        public string Code { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public decimal Ask { get; set; }
        public decimal Offer { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
    }
}