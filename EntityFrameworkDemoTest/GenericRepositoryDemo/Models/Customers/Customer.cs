using System;
using System.ComponentModel.DataAnnotations;
using GenericRepositoryDemo.Models.Interfaces;

namespace GenericRepositoryDemo.Models.Customers
{
    public class Customer : IEntity<string>
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Created {get; set; }
        public DateTime LastModified { get; set; }
        public Customer()
        {
            Created = DateTime.Now;
            LastModified = DateTime.Now;    
        }
        public Customer(string email,string name ) : this()
        {
            this.Name = name;
            this.Id = email;
        }

        public override string ToString() =>  string.Format($"{Name}");
        
    }

}
