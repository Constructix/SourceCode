using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MassTransit.MessageContract
{
    public class UpdateCustomerAdress : IUpdateCustomerAddress
    {
        [Key]
        public Guid CommandId { get; }
        public DateTime Timestamp { get; }
        
        public string CustomerId { get; }
        public string HouseNumber { get; }
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }

        public UpdateCustomerAdress()
        {
            this.Timestamp = DateTime.Now;
        }

        public UpdateCustomerAdress(Guid id, string customerId, DateTime timestamp)
        {
            this.CommandId = id;
            this.CustomerId = customerId;
            this.Timestamp = timestamp;

        }

        public UpdateCustomerAdress(Guid commandId, DateTime timestamp, string customerId, string houseNumber, string street, string city, string state, string postalCode)
        {
            CommandId = commandId;
            Timestamp = timestamp;
            CustomerId = customerId;
            HouseNumber = houseNumber;
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }
    }
}