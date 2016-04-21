using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFCustomBehaviors.Contracts
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
}