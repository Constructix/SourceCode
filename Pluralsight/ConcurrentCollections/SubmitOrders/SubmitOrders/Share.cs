using System;

namespace SubmitOrders
{
    public class Share
    {
        public string Code { get; set; }
        public DateTime ShareDateTime { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public int Volume { get; set; }
    }
}