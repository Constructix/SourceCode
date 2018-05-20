using System;
using System.CodeDom;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerService = new CustomerService();
            var newOrderService = new OrderService(customerService);

            var customerId = "r_jones@constructix.com.au";  
            HandleRequest(newOrderService.Submit(customerId));
            HandleRequest(newOrderService.Submit("t_jones@constructix.com.au"));
        }
        static void HandleRequest(OrderSubmitResponse response)
        {
            if(response.Status == OrderSubmitStatus.Error)
                Console.WriteLine(response.Message);
            else
            {
                Console.WriteLine($"Status: {response.Status} ID: {response.Document.Id}");
            }
        }

    }
}
