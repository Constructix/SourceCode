using System;

namespace Constructix.Services.DomainModel
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public Customer()
        {
            
        }

        public Customer(Guid id)
        {
            Id = id;
        }
    }
}
