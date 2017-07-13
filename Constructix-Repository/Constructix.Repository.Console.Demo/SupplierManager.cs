using System;
using System.Linq;
using Constructix.Business.Data.Database;
using Constructix.Business.Data.Entities;

namespace Constructix.Repository.Console.Demo
{
    class SupplierManager
    {
        public static GenericRepository<Supplier, Guid, Database> CreateSuppliers(Database db)
        {
            GenericRepository<Supplier, Guid, Database> supplierRepo = new GenericRepository<Supplier, Guid, Database>(db);
            AddSuppliers(supplierRepo);
            return supplierRepo;
        }

        public static void AddSuppliers(GenericRepository<Supplier, Guid, Database> supplierRepo)
        {
            string[] supplierName = new string[]
                {"Chermisde Building Centre", "Narangba Timbers", "Bunnings Stafford", "Bretts Hardware", "Narangba Timber Supplies"};

            foreach (string currentSupplierName in supplierName)
            {
                Supplier newSupplier = new Supplier { Name = currentSupplierName };
                supplierRepo.Add(newSupplier);
                supplierRepo.Save();
            }
        }


        public static void PrintSupplier(GenericRepository<Supplier, Guid, Database> supplierRepo)
        {

            string SupplierId = "Supplier Id";
            string Name = "Supplier Name";

            System.Console.WriteLine("Suppliers");
            System.Console.WriteLine();

            System.Console.WriteLine($"{SupplierId,-36}{Name}");
            System.Console.WriteLine(new string('-', 80));

            var suppliers = supplierRepo.GetAll().ToList();
            foreach (Supplier currentSupplier in suppliers)
            {
                System.Console.WriteLine($"{currentSupplier.Id} {currentSupplier.Name}");
            }
        }
    }
}