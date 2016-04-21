using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFCustomBehaviors.Contracts;

namespace WCFCustomBehaviors.Proxies
{
    public class MerchantServiceClient : ClientBase<IMerchantService>, IMerchantService
    {
        public string GetClientId(string email)
        {
            return Channel.GetClientId(email);
        }

        public Account GetAccount(string accountId)
        {
            return Channel.GetAccount(accountId);
        }

        public List<Product> GetProducts()
        {
            return Channel.GetProducts();
        }

        public SubmitResponse SubmitOrder(Order order)
        {
            return Channel.SubmitOrder(order);
        }
    }
}