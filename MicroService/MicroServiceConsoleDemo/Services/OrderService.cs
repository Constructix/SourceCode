using System;
using ConsoleApp1.Events;

namespace ConsoleApp1
{
    public class OrderService
    {

        private readonly OrderServiceOrchestration _orchestrator;
        public event EventHandler<OrderCreatedEventArgs> OrderCreated;
        public event EventHandler<CustomerDoesNotExistEventArgs> CustomerDoesNotExistHandler;

        private OrderSubmitResponse Response { get; set; }
        public OrderService()
        {
            Response = new OrderSubmitResponse();
        }

        private void _orchestrator_OrderCreated(object sender, OrderCreatedEventArgs e)
        {
            Response.Status = OrderSubmitStatus.Ok;
            Response.Message = "Order has been created";
            Response.Created = e.Created;
            Response.Document = new Order(Guid.NewGuid());
        }

        private void _orchestrator_CustomerExistHandler(object sender, CustomerExistEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _orchestrator_CustomerDoesNotExistHandler(object sender, CustomerDoesNotExistEventArgs e)
        {
            Response.Status = OrderSubmitStatus.Error;
            Response.Message = e.Message;
        }

        public OrderService(CustomerService customerService) : this()
        {
            _orchestrator = new OrderServiceOrchestration(customerService);
            _orchestrator.CustomerDoesNotExistHandler += _orchestrator_CustomerDoesNotExistHandler;
            _orchestrator.CustomerExistHandler += _orchestrator_CustomerExistHandler;
            _orchestrator.OrderCreated += _orchestrator_OrderCreated;
           
        }

        public OrderSubmitResponse Submit(string customerId)
        {
            _orchestrator.CreateOrder(customerId);
            return Response;
        }
    }
}