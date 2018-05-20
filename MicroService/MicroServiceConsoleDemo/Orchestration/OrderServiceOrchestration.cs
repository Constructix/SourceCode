using System;
using ConsoleApp1.Events;

namespace ConsoleApp1
{

    public class CustomerServiceOrchestration
    {

    }

    public class OrderServiceOrchestration
    {

        private readonly CustomerService CustomerService;

        public event EventHandler<OrderCreatedEventArgs> OrderCreated;
        public event EventHandler<CustomerDoesNotExistEventArgs> CustomerDoesNotExistHandler;
        public event EventHandler<CustomerExistEventArgs> CustomerExistHandler;

        public OrderServiceOrchestration(CustomerService customerService)
        {
            this.CustomerService = customerService;
        }

        public void CreateOrder(string customerId)
        {
            if (CustomerService.GetCustomer(customerId) == null)
            {
                EventHandler<CustomerDoesNotExistEventArgs> customerDoesNotExistHandler = CustomerDoesNotExistHandler;
                customerDoesNotExistHandler?.Invoke(this, new CustomerDoesNotExistEventArgs(customerId));
            }
            else
            {
                // reserve credit for customer


                EventHandler<OrderCreatedEventArgs> orderCreatedHandler = OrderCreated;
                orderCreatedHandler?.Invoke(this, new OrderCreatedEventArgs());
            }
        }
    }
}