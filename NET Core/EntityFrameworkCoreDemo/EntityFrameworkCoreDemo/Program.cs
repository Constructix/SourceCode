/*
 * Install-Package Microsoft.EntityFrameworkCore -Version 2.0.3 
 * Install-Package Microsoft.EntityFrameworkCore.SqlServer
 * Install-Package Microsoft.EntityFrameworkCore.Relational
 * install-package System.Configuration.Configurationmanager
 *
 */

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Configuration;
using System.IO;
using EntityFrameworkCoreDemo.Contexts;
using EntityFrameworkCoreDemo.Repositories;

namespace EntityFrameworkCoreDemo
{
    class Program
    {
        public static string ServerName => ConfigurationManager.AppSettings["ServerName"];
        public static string DatabaseName => ConfigurationManager.AppSettings["Database"];

        static void Main(string[] args)
        {
            // OnLineServices2Database();
            string  connectionString = $"Data Source={ServerName};Initial Catalog={DatabaseName};Integrated Security=SSPI;";

            var builder = new DbContextOptionsBuilder<OnLineServicesGeneric>();
            builder.UseSqlServer(connectionString);


            using (OnLineServicesGeneric onlineServicesContext = new OnLineServicesGeneric(builder))
            {
                onlineServicesContext.Database.EnsureCreated();
                GenericRepository<OnLineServicesGeneric, Category, int> categoryRepository =
                    new GenericRepository<OnLineServicesGeneric, Category, int>(onlineServicesContext);

                Console.WriteLine("Creating Databases....");
                AddCategories(categoryRepository);
                foreach (Category currentCategory in categoryRepository.GetAll())
                {
                    Console.WriteLine($"{currentCategory.Id} {currentCategory.Name}");
                }
                string fileName = @"D:\Files\Suppliers.csv";
                var suppliers = AddSuppliers(onlineServicesContext, categoryRepository, fileName);

                Console.WriteLine("Suppliers");
                foreach (Supplier supplier in suppliers)
                {
                    Console.WriteLine($"{supplier.Id} {supplier.Name}");
                }
                
            }
        }

        private static List<Supplier> AddSuppliers(OnLineServicesGeneric onlineServicesContext, 
                                         GenericRepository<OnLineServicesGeneric, Category, int> categoryRepository,
            string fileName)
        {
            
            GenericRepository<OnLineServicesGeneric, Supplier, int> supplierRepository = new GenericRepository<OnLineServicesGeneric, Supplier, int>(onlineServicesContext);
            
            using (FileStream fileStream = File.OpenRead(fileName))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (reader.Peek() != -1)
                    {
                        string[] currentLine = reader.ReadLine()?.Split(new char[] {','});
                        if (currentLine != null && currentLine.Length == 2)
                        {
                            string supplierName = currentLine[0];
                            int categoryId;
                            if (int.TryParse(currentLine[1], out categoryId))
                            {
                                bool suppliersToAdd = false;
                                var supplierCategory = categoryRepository.Get(categoryId);
                                if (supplierCategory != null)
                                {
                                    Supplier newSupplier = new Supplier
                                    {
                                        Name = supplierName,
                                        CategoryId = supplierCategory.Id
                                    };
                                    if (!supplierRepository.GetAll(x => x.Name.Equals(newSupplier.Name)).Any())
                                    {
                                        suppliersToAdd = true;
                                        supplierRepository.Add(newSupplier);
                                    }
                                }
                                if (suppliersToAdd)
                                    supplierRepository.SaveChanges();
                            }
                        }
                    }
                }
            }

            return supplierRepository.GetAll().ToList();
        }

        private static void AddCategories(GenericRepository<OnLineServicesGeneric, Category, int> categoryRepository)
        {
            List<Category> categories = new List<Category>
            {
                new Category {Name = "Landscaping"},
                new Category {Name = "Timber and Hardware"}
            };

            bool itemsToBeAdded = false;

            foreach (Category category in categories)
            {
                if (!categoryRepository.GetAll(x => x.Name.Equals(category.Name)).Any())
                {
                    categoryRepository.Add(category);
                    itemsToBeAdded = true;
                }

                if (itemsToBeAdded)
                    categoryRepository.SaveChanges();
            }
        }

        private static void OnLineServices2Database()
        {
            Console.WriteLine("Using .NET Core");
            Console.WriteLine("Using EntityFramework.Core");
            Console.WriteLine(new string('-', 80));


            var connectionString =
                $"Data Source={ServerName};Initial Catalog=OnLineServicesVersion2;Integrated Security=SSPI;";


            var builder = new DbContextOptionsBuilder<OnLineServicesVersion2Context>();
            builder.UseSqlServer(connectionString);
            using (OnLineServicesVersion2Context db = new OnLineServicesVersion2Context(builder))
            {
                if (db.Database.EnsureCreated())
                {
                    Console.WriteLine("Creating database....");
                    AddCategories(db);
                    AddSuppliers(db);
                    db.SaveChanges();
                    Console.WriteLine($"Created and populated tables in ");
                }
                else
                {
                    string supplierColumnName = "Supplier";
                    Console.WriteLine("Database already created...");
                    Console.WriteLine("Suppliers");
                    Console.WriteLine(new string('-', 80));
                    Console.WriteLine($"{supplierColumnName,-30}");
                    foreach (Supplier dbSupplier in db.Suppliers)
                    {
                        Console.WriteLine(dbSupplier.Name);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Categories");
                    foreach (var currentCategory in db.Categories)
                    {
                        Console.WriteLine($"{currentCategory.Id} {currentCategory.Name}");
                    }
                }
            }
        }

        private static void AddCategories(OnLineServicesVersion2Context db)
        {
            db.Categories.Add(new Category {Name = "Landscaping"});
            db.Categories.Add(new Category {Name = "Timber and Hardware"});
            db.SaveChanges();
        }
        private static void AddSuppliers(OnLineServicesVersion2Context db)
        {
            string[,] suppliers = new string[,]
            {
                {"Narangba Timbers", "http://www.NarangbaTimbers.com.au","Timber and Hardware" },
                {"Sapar Landscaping", "http://www.sapar.com.au", "Landscaping"}
            };
            for (int x = 0; x < suppliers.GetLength(0); x++)
            {
                var supplier = new Supplier
                {
                    Name = suppliers[x,0],
                    WebAddress = suppliers[x, 1]
                };
                var categoryName = suppliers[x, 2];
                supplier.CategoryId = db.Categories.FirstOrDefault(s => s.Name.Equals(categoryName)).Id;
                db.Suppliers.Add(supplier);
            }
        }
    }

    public class OnLineServicesVersion2Context : DbContext
    {
        public DbSet<Supplier> Suppliers { get;set;}
        public DbSet<Category> Categories { get;set;}

        public OnLineServicesVersion2Context() : base()
        {
        }
        public  OnLineServicesVersion2Context(DbContextOptionsBuilder<OnLineServicesVersion2Context> builder) : base(builder.Options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
