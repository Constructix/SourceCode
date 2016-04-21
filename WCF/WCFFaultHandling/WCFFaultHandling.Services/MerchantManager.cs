using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using WCFFaultHandling.Contracts;

namespace WCFFaultHandling.Services
{
   // [ArgumentExceptionHandler] can also do  this in the config file.

    public class MerchantManager : IMerchantService, IServiceBehavior
    {
        private List<Account> _accounts;
        public MerchantManager()
        {
            _accounts = new List<Account>
            {
                new Account {Email="r_jones@constructix.com.au", Id = "B20EBED7-6E63-481C-90F1-6C3F533ABECB", FirstName = "Richard", LastName = "Jones"},
                new Account {Email="t_jones@constructix.com.au", Id = "160934BF-18C0-4C64-A2FC-5CA065D2A592" , FirstName = "Teresa", LastName = "Jones"},
                new Account {Email="rjjones79@hotmail",          Id = "202222F3-FD59-48E2-B1EE-7906CF6852B1" , FirstName = "Richard", LastName = "Jones"}
            };
        }
        public string GetClientId(string email)
        {

           return  _accounts.Any(x => x.Email.Equals(email)) == true ? _accounts.FirstOrDefault(x => x.Email.Equals(email)).Id : string.Empty;

        }

        public Account GetAccount(string accountId)
        {
            return _accounts.Find(x=>x.Id.Equals(accountId));
        }
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "90x90 Post", UnitPrice = 14.40m},
                new Product { Id = 1, Name = "110x90 Post", UnitPrice = 16.50m},
            };
        }

        public SubmitResponse SubmitOrder(Order order)
        {
            Console.WriteLine("Submit Order for Product has been received.");
            if(order.Account != null && !string.IsNullOrEmpty(order.Account.Id))
                Console.WriteLine("\t\tClient Id: {0}", order.Account.Id.ToString());


            if (!order.OrderItems.Any())
            {
                ArgumentException ex = new ArgumentException("There are no OrderItems in order.");
                throw ex;
            }
            string newID = Guid.NewGuid().ToString();
            // process order etc
            Console.WriteLine("Processing order. ");
            Console.WriteLine();
            Console.WriteLine("Order has been processed.");

            var resposne = new SubmitResponse {Id =newID, Status = "Ok"};
            return resposne;
        }


        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ServiceEndpoint serviceEndpoint in serviceDescription.Endpoints)
            {
                if (serviceEndpoint.Contract.Name.Equals("IMerchantService"))
                {
                    if (serviceEndpoint.Contract.Operations.Where(currentOperationDescription => currentOperationDescription.Name.Equals("SubmitOrder")).Any(currentOperationDescription => currentOperationDescription.Faults.FirstOrDefault(x => x.DetailType == typeof(ArgumentException)) == null))
                    {
                        throw new InvalidOperationException("SubmitOrder operation requires a fault contract for ArgumentException");
                    }
                }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            
        }
    }
}
