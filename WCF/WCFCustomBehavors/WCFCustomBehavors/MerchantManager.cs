using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using WCFCustomBehaviors.Contracts;

namespace WCFCustomBehaviors.Service
{
    public class MerchantManager: IMerchantService
    {
        public string GetClientId(string email)
        {
            return "asdf";
        }

        public Account GetAccount(string accountId)
        {
            return new Account();
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
            
            return new SubmitResponse {Status = "OK"};
        }
    }
}
