using System;
using System.Data.SqlTypes;
using Newtonsoft.Json;

namespace RabbitMQ.Common
{

    public interface IBusinessObject
    {
        string ToJson();

    }

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


    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public Customer Customer { get; set; }


        public Order()
        {
            Id = Guid.NewGuid();
            Customer = new Customer();
        }

        
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}