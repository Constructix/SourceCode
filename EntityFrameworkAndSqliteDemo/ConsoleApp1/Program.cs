using System;
using System.Linq;
using EntityFrameworkAndSqlite.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkAndSqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demostrating using Entity framework and Sqlite.");

            using (var context = new MyContext())
            {
                try
                {
                    var nextId = context.Customers.Max(x => x.CustomerId) + 1;
                    var customer = new Customer
                    {
                        CustomerId = nextId,
                        FirstName = "Richard",
                        LastName = "Jones",
                        Address = "23 Tsawassen Blvd."
                    };

                    context.Customers.Add(customer);

                    context.SaveChanges();


                    foreach (var currentCustomer in context.Customers)
                    {
                        Console.WriteLine(currentCustomer.FirstName);
                    }
                }
                catch (SqliteException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                }
                catch (Exception e)
                {

                    if (e.InnerException is SqliteException)
                    {

                        var sqlEx = e.InnerException as SqliteException;
                        Console.WriteLine("SqlIte exception encountered.");
                        if (sqlEx != null)
                        {
                            Console.WriteLine(sqlEx.SqliteErrorCode);
                            Console.WriteLine(sqlEx.SqliteExtendedErrorCode);
                        }
                    }
                    else
                        Console.WriteLine(e);
                    
                }
            }

        }
    }



    public class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=D:\Development\GitHub\EntityFrameworkAndSqliteDemo\ConsoleApp1\Database\CustomerDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Invoice>().ToTable("Invoices");
            modelBuilder.Entity<InvoiceItem>().ToTable("InvoiceItems");
        }
    }
}
