using System;
using GenericServices.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericServices.Data
{

    public class CustomersContext : DbContext
    {
        public DbSet<CustomerDTO> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=localhost;Initial Catalog=CQRS_Customers;Integrated Security=SSPI;");
        }
    }

    public class CustomerDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerDTO()
        {
        }
    }
}
