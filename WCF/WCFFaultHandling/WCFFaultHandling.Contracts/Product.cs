﻿using System.Runtime.Serialization;

namespace WCFFaultHandling.Contracts
{
    [DataContract]
    public class Product
    {
        [DataMember]
         public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
    }

   
}