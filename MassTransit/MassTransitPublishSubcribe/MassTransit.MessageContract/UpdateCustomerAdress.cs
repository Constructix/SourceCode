using System;

namespace MassTransit.MessageContract
{
    public class UpdateCustomerAdress : IUpdateCustomerAddress
    {
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

        }

        public UpdateCustomerAdress(string customerId)
        {
            this.CustomerId = customerId;
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