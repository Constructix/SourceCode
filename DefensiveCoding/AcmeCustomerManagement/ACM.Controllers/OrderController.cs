using ACM.BusinessLogic;
using ACM.Repository;
using Core.Common;

namespace ACM.Controllers
{
    public class OrderController
    {
        private readonly CustomerRepository _customerRepository;
        private readonly InventoryRepository _inventoryRepository;
        private readonly OrderRepository _orderRepository;
        private readonly EmailLibrary _emailLibrary;


        public OrderController()
        {
            _inventoryRepository = new InventoryRepository();
            _customerRepository = new CustomerRepository();
            _orderRepository = new OrderRepository();
            _emailLibrary = new EmailLibrary();
        }

        public OrderController( InventoryRepository inventoryRepository, 
                                CustomerRepository customerRepository,
                                OrderRepository orderRepository, EmailLibrary emailLibrary)
        {
            _inventoryRepository =inventoryRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _emailLibrary = emailLibrary;
        }



        public  void PlaceOrder(Customer customer, 
                                Order order, 
                                Payment payment, 
                                bool allowSplitOrders, 
                                bool emailReceipt)
        {
            _customerRepository.Add(customer);
            _orderRepository.Add(order);
            _inventoryRepository.OrderItems(order, allowSplitOrders);

            payment.Process(payment);


            if (emailReceipt)
            {
                customer.ValidateEmail();
                _customerRepository.Update();

                _emailLibrary.SendEmail(customer.EmailAddress, "Here is your receipt");
            }
        }
    }
}
