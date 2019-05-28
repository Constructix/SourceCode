using System;
using Newtonsoft.Json;

namespace OrdersDomain
{
   public class Order
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public Order()
        {

            Id = Guid.NewGuid();
            Created = DateTime.Now.ToUniversalTime();
        }
        public Order(Guid id, DateTime created)
        {
            Id = id;
            Created = created;
        }

        public static string ToJson(Order currentOrder)
        {
            return JsonConvert.SerializeObject(currentOrder);
        }

    }
}
