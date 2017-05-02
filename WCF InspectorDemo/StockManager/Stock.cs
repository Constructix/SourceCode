using System.Runtime.Serialization;

namespace StockManager
{
    [DataContract]
    public class Stock
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public decimal BuyPrice { get; set; }
        [DataMember]
        public decimal SellPrice { get; set; }
       
    }
}