﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;

namespace CarRental.Business.Entities
{
    [DataContract]
    public class Car : EntityBase, IIdentifiableEntity  
    {
        [DataMember]
        public int CardId { get; set; }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public decimal RentalPrice { get; set; }
        [DataMember]
        public bool CurrentlyRented { get; set; }


        public int EntityId { get; set; }
    }
}
