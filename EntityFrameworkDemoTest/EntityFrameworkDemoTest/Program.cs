using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //UseContextDirectly();
            var customerDB = new CustomerContext();
            var customerRepository = new CustomerRepository(customerDB);

            var outputWriter = new OutputWriter<string>();
            outputWriter.Print("Using Async call to get all Customers..");
           
            PrintCustomerDetails(customerRepository);
            outputWriter = new OutputWriter<string>();
            outputWriter.Print("Finishied getting customers.");

            // adding a new Customer
            var customer = new Customer("t_jones@constructix.com.au", "Teresa Jones");
            AddCustomer(customerRepository,customer );
            AddCustomer(customerRepository, new Customer("rjjones79@hotmail.com", "Richard Jones"));
            AddCustomer(customerRepository, new Customer("r_jones@constructix.com.au", "Richard Jones"));
            PrintCustomerDetails(customerRepository);

            // update Customer, change name from Richard Jones to Richard John Jones
            var selectedCustomer = customerRepository.GetCustomer("t_jones@constructix.com.au");
            Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("Updating customer ");
            selectedCustomer.Name = "Teresa Anne Jones";

            customerRepository.Update(selectedCustomer);
            customerRepository.SaveChanges();
            Console.WriteLine();
            PrintCustomerDetails(customerRepository);

        }

        private static void AddCustomer(CustomerRepository customerRepository, Customer customer)
        {
            var customerAdded = customerRepository.Add(customer);
            if (!customerAdded)
            {
                Console.WriteLine($"Attempted to add {customer.Name} - Customer already exists -");
            }
        }

        private static void PrintCustomerDetails(CustomerRepository customerRepository)
        {
            const string emailHeader = "Email";
            const string nameHeader = "Name";

            Console.WriteLine($"{emailHeader, -30}{nameHeader, -30}");
            Console.WriteLine($"{new string('-', 60)}");
            var t = new TaskFactory().StartNew(() =>
            {
                var result = customerRepository.GetAllAsync();

                foreach (Customer currentCustomer in result.Result.ToList())
                {
                    Console.WriteLine($"{currentCustomer.Id,-30}{currentCustomer.Name, -30}");
                }
            });
            t.Wait();
        }

        private static void UseContextDirectly()
        {
            // code below uses the Database/Context directly...
            var CustomerDB = new CustomerContext();

            var newCustomer = new Customer("r_jones@constructix.com.au", "Richard Jones");

            if (CustomerDB.Customers.Find(newCustomer.Id) == null)
            {
                CustomerDB.Customers.Add(newCustomer);
                CustomerDB.SaveChanges();
                var outputWriter = new OutputWriter<Customer>();
                outputWriter.PrintList(CustomerDB.Customers.ToList());
            }
            else
            {
                var outputWriter = new OutputWriter<string>();
                outputWriter.Print($"Customer {newCustomer.Id} already exists.");
            }
        }
    }

    public class OutputWriter<T>
    {
        public  void PrintList(List<T> items)
        {
            foreach (var currentItem in items )
            {
                Console.WriteLine(currentItem.ToString());
            }
        }

        public void Print(T Item)
        {
            Console.WriteLine(Item.ToString());
        }
    }

    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }

        DateTime Created { get; set; }

        DateTime LastModified {get; set; }
    }


    public class Order: IEntity<int>
    {
        private int _id;
        private DateTime _created;
        private DateTime _lastModified;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime Created
        {
            get => _created;
            set => _created = value;
        }

        public DateTime LastModified
        {
            get => _lastModified;
            set => _lastModified = value;
        }


    }


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


    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("Data Source=SYD00VR01225;Initial Catalog=Customers;Integrated Security=SSPI;")
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
    }


    public  class GenericRepository<TContext, TEntity> where TContext: DbContext 
                                                            where TEntity : class 
                                                            
    {
        protected DbContext Context { get; set; }

        protected DbSet<TEntity> Entity {get; set; }

        public GenericRepository()
        {
            
        }

        public GenericRepository(TContext context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Entry(Entity).Entity.ToListAsync();
        }

        public void Add(TEntity newEntity)
        {
            Context.Set<TEntity>().Add(newEntity);
        }


    }

    public class CustomerRepository
    {

        private CustomerContext database;

        public CustomerRepository()
        {
            
        }

        public CustomerRepository(CustomerContext customerDatabase)
        {
            database = customerDatabase;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await database.Customers.ToListAsync();
        }

        public bool Add(Customer newCustomer)
        {
            bool customerAdded = false;
            if(database.Customers.Find(newCustomer.Id) == null)
            {
                database.Customers.Add(newCustomer);
                database.SaveChanges();
                customerAdded = true;
            }

            return customerAdded;
        }

        public Customer GetCustomer(string key)
        {
            return database.Customers.Find(key);
        }

        public void Update(Customer customer)
        {
            if (database.Customers.Find(customer.Id) != null)
            {
                customer.LastModified = DateTime.Now;
                database.Entry(customer).State = EntityState.Modified;
               
            }
        }
        public void SaveChanges()
        {
            database.SaveChanges();
        }
    }

}
