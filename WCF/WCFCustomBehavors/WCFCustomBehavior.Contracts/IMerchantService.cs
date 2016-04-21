using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFCustomBehaviors.Contracts
{
    [ServiceContract]
    public interface IMerchantService
    {


        [OperationContract]
        string GetClientId(string email);

        [OperationContract]
        Account GetAccount(string accountId);

        [OperationContract]
        List<Product> GetProducts();

        [OperationContract]
        SubmitResponse SubmitOrder(Order order);
    }
}
