using System;
using System.ComponentModel.DataAnnotations;

namespace MassTransit.Data
{
    public class AddressDetails
    {
        [Key]
        public Guid Id { get; set; }
        public string CustomerId { get; set; }


        public DateTime Created { get; set; }


        public AddressDetails()
        {
            Created = DateTime.Now;
        }

    }
}