using System.ServiceModel;

namespace StockManager
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        Stock GetStock(string stockCode);
    }
}