using System;
using System.ComponentModel.DataAnnotations;

namespace RepositoryUnitOfWorkDemo
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public Order()
        {
            Created = DateTime.Now;
        }
    }
}