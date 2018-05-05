using System;
using System.ComponentModel.DataAnnotations;
using GenericRepositoryDemo.Models.Interfaces;

namespace GenericRepositoryDemo.Models.Order
{
    public class Order: IEntity<int>
    {
        public string CustomerId { get; set; }


        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public Order() 
        {
            this.Created = DateTime.Now;
            this.LastModified = DateTime.Now;
        }
    }
}