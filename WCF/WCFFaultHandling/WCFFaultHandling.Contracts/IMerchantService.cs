using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFFaultHandling.Contracts
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
        [FaultContract(typeof(ArgumentException))]
        SubmitResponse SubmitOrder(Order order);
    }
}