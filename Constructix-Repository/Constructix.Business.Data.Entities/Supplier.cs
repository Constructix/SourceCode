using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Constructix.Business.Data.Entities
{
    public class Supplier : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public string Name { get; set; }

        public  virtual ICollection<Order> Orders { get; set; }

        public Supplier()
        {
            Id = Guid.NewGuid();
            Orders= new List<Order>();
            Created = DateTime.Now;
        }

    }
}