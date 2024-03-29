﻿using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace CarRental.Business.Entities
{
    [DataContract]
    public class Account : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int AccountId { get; set; }
        [DataMember]
        public string LoginEmail { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string CreditCard { get; set; }
        [DataMember]
        public string ExpDate { get; set; }

        
        public int EntityId { get { return AccountId; } set { AccountId = value; } }
    }
}