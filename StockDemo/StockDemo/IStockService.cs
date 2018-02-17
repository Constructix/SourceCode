using System.ServiceModel;

namespace StockDemo
{

    [ServiceContract]
    public interface IStockService
    {

        [OperationContract]
        StockResponseDocument GetListing(string stockCode);

    }
}