using System.ServiceModel;

namespace StockDemo
{
    public class StockService : IStockService
    {
        public StockResponseDocument GetListing(string stockCode)
        {
            StockResponseDocument response = null;
            
            // for dummy purposes
            switch (stockCode.ToUpper())
            {
                case "GXY":
                    response =  GalaxyDetails();
                    break;
                case "LPD":
                    response =  LPDDetails();
                    break;
                default:
                    throw new FaultException<string>("Invalid stock code supplied.");
                    break;
            }

            return response;
        }

        private StockResponseDocument GalaxyDetails() => new StockResponseDocument(3.45m, "Galaxy Resources", "GXY");
        private StockResponseDocument LPDDetails() => new StockResponseDocument(0.056m, "Lepidico", "LPD");
    }
}