using System;

namespace WatchListAnalysis
{
    public class Stock : IStock
    {
        public string Code { get; set; }
        public DateTime DateTimeRecorded { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Last { get; set; }
        public int Volume { get; set; }
    }
}