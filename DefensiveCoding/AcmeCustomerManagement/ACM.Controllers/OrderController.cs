using ACM.BusinessLogic;
using ACM.Repository;
using Core.Common;

namespace ACM.Controllers
{
    public class OrderController
    {
        public  void PlaceOrder(Customer customer, Order order, Payment payment, bool allowSplitOrders, bool emailReceipt)
        {
            var inventoryRepository = new InventoryRepository();
            var customerRepository = new CustomerRepository();
            customerRepository.Add(customer);
            var orderRepository = new OrderRepository();
            orderRepository.Add(order);
            inventoryRepository.OrderItems(order, allowSplitOrders);

            payment.Process(payment);


            if (emailReceipt)
            {
                customer.ValidateEmail();
                customerRepository.Update();

                var emailLibrary = new EmailLibrary();
                emailLibrary.SendEmail(customer.EmailAddress, "Here is your receipt");
            }
        }
    }
}
