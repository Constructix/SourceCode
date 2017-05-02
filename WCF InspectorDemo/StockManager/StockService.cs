namespace StockManager
{
    public class StockService : IStockService
    {
        public Stock GetStock(string stockCode)
        {

            System.Console.WriteLine("Request has been received.");
            if (!string.IsNullOrEmpty(stockCode))
            {
                if (stockCode.Equals("GXY")) return new Stock {Code = "GXY", BuyPrice = 0.433m, SellPrice = 0.41m};
                if (stockCode.Equals("MSFT")) return new Stock {Code = "MSTF", BuyPrice = 98.34m, SellPrice = 91.23m};
                else
                {
                    return new Stock();
                }
            }
            return new Stock();
        }
    }
}