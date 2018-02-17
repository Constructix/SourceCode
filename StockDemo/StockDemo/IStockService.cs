using System.ServiceModel;

namespace StockDemo
{

    [ServiceContract]
    public interface IStockService
    {

        [OperationContract]
        StockResponseDocument GetPrice(string stockCode);

    }
}