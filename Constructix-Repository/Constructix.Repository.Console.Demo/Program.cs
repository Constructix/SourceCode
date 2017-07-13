using System;
using System.Collections.Generic;
using System.Linq;
using Constructix.Business.Data.Database;
using Constructix.Business.Data.Entities;

namespace Constructix.Repository.Console.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database("DataServices");

            var supplierRepo = SupplierManager.CreateSuppliers(db);

            Order newOrder = new Order
            {
                Supplier = supplierRepo.Get(x=>x.Name.Equals("Bretts Hardware")).FirstOrDefault()
            };
       
            OrderDetails(db, newOrder);
        }

        private static void OrderDetails(Database db, Order newOrder)
        {
            GenericRepository<Order, Guid, Database> orderRepo = new GenericRepository<Order, Guid, Database>(db);
            orderRepo.Add(newOrder);
            orderRepo.Save();
            PrintOrders(orderRepo);
        }


        private static void PrintOrders(GenericRepository<Order, Guid, Database> repo)
        {
            var orders = repo.GetAll();

            System.Console.WriteLine("Orders");
            System.Console.WriteLine(new String('-', 80));
            foreach (Order currentOrder in orders)
            {
                System.Console.WriteLine($"{currentOrder.Id, 30}{currentOrder.Supplier.Name }");
            }
        }
    }


    
}
