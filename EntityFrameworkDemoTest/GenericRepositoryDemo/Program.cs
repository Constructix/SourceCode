using System;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GenericRepositoryDemo.Contexts;
using GenericRepositoryDemo.Models.Customers;
using GenericRepositoryDemo.Models.Inventory;
using GenericRepositoryDemo.Models.Order;
using GenericRepositoryDemo.Models.OrderItem;
using GenericRepositoryDemo.Repositories;

namespace GenericRepositoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerContext customerContext = new CustomerContext(ConfigurationManager.AppSettings["CustomerDatabase"]);
            OrderContext orderContext = new OrderContext(ConfigurationManager.AppSettings["OrderDatabase"]);
            ProductContext productContext = new ProductContext(ConfigurationManager.AppSettings["ProductDatabase"]);

            GenericRepository<CustomerContext, Customer, string> customerRepository = new GenericRepository<CustomerContext, Customer, string>(customerContext);
<<<<<<< HEAD
            GenericRepository<OrderContext, Order, int> genericRepository = new GenericRepository<OrderContext, Order, int>(orderContext);
=======
            GenericRepository<OrderContext, Order, int> OrderRepository = new GenericRepository<OrderContext, Order, int>(orderContext);
>>>>>>> 4c011fb0028430c0e9392e757d3e9aa1ec8f6ff5
            GenericRepository<OrderContext, OrderItem, Guid> orderItemRepository = new GenericRepository<OrderContext, OrderItem, Guid>(orderContext);
            GenericRepository<ProductContext, Product, int> productRepository = new GenericRepository<ProductContext, Product, int>(productContext);

            // Create product and add product to product database.
            var newProduct = new Product();
            newProduct.Name = "Bedding Sand - Bag";
            newProduct.UnitPrice = 6.60m;

            productRepository.Add(newProduct);
            productRepository.SaveChanges();

            PrintList(productRepository);
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // setup Customer
            Customer newCustomer = customerRepository.Get("r_jones@constructix.com.au"); 
            if (newCustomer == null)
            {

                Console.WriteLine("Adding customer record.");
                customerRepository.Add(new Customer("r_jones@constructix.com.au", "Richard Jones"));
                customerRepository.SaveChanges();
            }

            newCustomer = customerRepository.Get("r_jones@constructix.com.au"); 
            var newOrder = new Order();
            newOrder.CustomerId = newCustomer.Id;
<<<<<<< HEAD
            genericRepository.Add(newOrder);
            genericRepository.SaveChanges();
=======
            OrderRepository.Add(newOrder);
            OrderRepository.SaveChanges();
>>>>>>> 4c011fb0028430c0e9392e757d3e9aa1ec8f6ff5
            Console.WriteLine("All Orders on Record");

            
            var t = new TaskFactory().StartNew(() =>
            {
<<<<<<< HEAD
                var result = genericRepository.GetAllAsync();
=======
                var result = OrderRepository.GetAllAsync();
>>>>>>> 4c011fb0028430c0e9392e757d3e9aa1ec8f6ff5

                foreach (Order currentCustomer in result.Result.ToList())
                {
                    Console.WriteLine($"{currentCustomer.Id,-30}{currentCustomer.Created.ToString(),-30}");
                }
            });
            t.Wait();

<<<<<<< HEAD
            var order = genericRepository.Get(1);
=======
            var order = OrderRepository.Get(1);
>>>>>>> 4c011fb0028430c0e9392e757d3e9aa1ec8f6ff5

            if (order != null)
            {
                Random random = new Random((int) DateTime.Now.Ticks);

                Console.WriteLine(order.Created);
                for (int index = 0; index < 10; index++)
                {


                    var newOrderItem = new OrderItem {OrderId = order.Id, Order = order, QuantityRequired = random.Next(0, 20)};
                    orderItemRepository.Add(newOrderItem);
                    orderItemRepository.SaveChanges();
                }

            }
            else
            {
                Console.WriteLine("Order is NOT FOUND");
            }
            Console.WriteLine();
            Console.WriteLine();
            t = new TaskFactory().StartNew(() =>
            {
                var result = orderItemRepository.GetAllAsync();

                foreach (OrderItem currentOrderItem in result.Result.ToList())
                {
                    Console.WriteLine($"{currentOrderItem.Id,-30}{currentOrderItem.OrderId, -30}");
                }
            });
            t.Wait();



        }

        private static void PrintList(GenericRepository<ProductContext, Product, int> productRepository)
        {
            var t = new TaskFactory().StartNew(() =>
            {
                var result = productRepository.GetAllAsync();

                foreach (Product product in result.Result.ToList())
                {
                    Console.WriteLine($"{product.Id,-30}{product.Name,-30}");
                }
            });
            t.Wait();
        }
    }
}
