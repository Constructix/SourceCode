using System;
using System.Data.Entity;
using System.Linq;
using NUnit.Framework;

namespace BaseServiceTest
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        [Test]
        public void CustomerRepository()
        {
            Customer newCustomer = new Customer() {FirstName = "Richard"};

            var custRepo = new CustomerRepository();

            custRepo.Add(newCustomer);
            custRepo.Add(new Customer { FirstName = "Teresa"});


            var customers = custRepo.Get(x=>!string.IsNullOrEmpty(x.FirstName)).ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }
        }


        [Test]
        public void OrderRepository_Instance_Created()
        {
            var orderRepo = new OrderRepository();

            orderRepo.Add(new Order {Created =  DateTime.Today});
            orderRepo.Add(new Order { Created = DateTime.Today.AddDays(-3) });
            orderRepo.Add(new Order { Created = DateTime.Today.AddDays(-6) });
            orderRepo.Add(new Order { Created = DateTime.Today.AddDays(-16) });

            var orders = orderRepo.Get();

            foreach (Order currentOrder in orders)
            {
                Console.WriteLine(currentOrder.Created.ToString());
            }
        }
    }


    [TestFixture]
    public class OrderFactoryTests
    {
        public class OnLineServicesContext : DbContext
        {
            public DbSet<Order> Orders { get; set; }
            public DbSet<Customer> Customers { get; set; }


            public OnLineServicesContext() : base("OnLineServices")
            {
                
            }
        }

        [Test]
        public void OrderFactory_Instance()
        {
            var orderfactory = new OrderFactory();

            var order = orderfactory.Create(new OrderInputData() {Created = DateTime.Today});

            Assert.IsNotNull(order);

            Assert.IsTrue(order.Created.Date.Equals(DateTime.Today));
        }

        [Test]
        public void OrderFactory_Receives_OrderInputData()
        {
            OrderInputData input = new OrderInputData() {Created = DateTime.Today};
            var orderFactory = new OrderFactory();
            var repo = new OrderRepository();
            var svc  =new BaseService<Order, OrderFactory, OrderRepository,OrderInputData>(orderFactory, repo);
            svc.Create(input);
            var custFactory   = new CustomerFactory();
            var custRepo = new CustomerRepository();
            CustomerInputData customerInput = new CustomerInputData() {FirstName = "Richard"};

            var customerService = new BaseService<Customer, 
                                                    CustomerFactory, 
                                                    CustomerRepository, 
                                                    CustomerInputData>(custFactory, custRepo);

            customerService.Create(customerInput);
        }


        public class BaseService<TObject, TBaseFactory, TBaseRespository, TInputData>
            where TObject : new()
            where TBaseFactory : IFactory<TObject, TInputData>
            where TBaseRespository : IRepository<TObject>
        {
            private TBaseFactory _factory;
            private TBaseRespository _repository;

            public BaseService(TBaseFactory factory, TBaseRespository repository)
            {
                _factory = factory;
                _repository = repository;
            }

            public void Create(TInputData inputData)
            {
                var instance = _factory.Create(inputData);
                if (instance != null)
                {
                   _repository.Add(instance);
                }
            }
        }



        public class OrderService
        {
            private BaseFactory<Order, OrderInputData> _factory;
            private BaseRepository<Order> _repository;


            public OrderService(BaseFactory<Order, OrderInputData> factory, BaseRepository<Order> repository )
            {
                _factory = factory;
                _repository = repository;
            }


            public void Create(OrderInputData inputData)
            {
                var order = _factory.Create(inputData);
                if (order != null)
                {
                    _repository.Add(order);
                }
            }
        }

        [Test]
        public void FactoryWithInterface()
        {
            
        }
}
   
}