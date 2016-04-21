using System.ServiceModel;

namespace WCFServiceBus.Contracts
{
    [ServiceContract]
    public interface IConstructixManager
    {
        [OperationContract]
        int Add(int number1, int number2);
    }
}