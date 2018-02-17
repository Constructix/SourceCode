using System;
using System.Runtime.Serialization;

namespace StockDemo
{
    [DataContract]
    public class StockResponseDocument
    {
        [DataMember] public decimal Price { get; set; }

        [DataMember] public DateTime ResponseCreated { get; set; }


        [DataMember] public string Company { get; set; }
        [DataMember] public string StockCode { get; set; }


        public StockResponseDocument(decimal price, string company, string stockCode)
        {
            this.Price = price;
            this.Company = company;
            this.StockCode = stockCode;
            this.ResponseCreated = DateTime.Now.ToUniversalTime();
        }
    }
}