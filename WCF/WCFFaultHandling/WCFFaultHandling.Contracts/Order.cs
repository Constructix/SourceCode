using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFFaultHandling.Contracts
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public Guid Id { get; set; }
        

        [DataMember]
        public List<OrderItem>  OrderItems { get; set; }


        [DataMember]
        public Account Account { get; set; }


        public Order()
        {
            
            OrderItems = new List<OrderItem>();
            Account = new Account();
        }
    }


    [DataContract]
    public class SubmitResponse
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Id { get; set; }
    }
}