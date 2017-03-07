using System;
using System.Data.SqlTypes;
using Newtonsoft.Json;

namespace RabbitMQ.Common
{
    public class Payload : IBusinessObject
    {
        public DateTime Created { get; set; }
        public string Message { get; set; }
        public Order Order { get; set; }

        public Payload()
        {
            Created = DateTime.Now;
            Order = new Order();
        }

        public string ToJson()
        {
           return JsonConvert.SerializeObject(this);
        }
    }
}