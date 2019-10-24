using System.Collections.Generic;

namespace WatchListAnalysis
{
    public interface ISharePriceExtractor
    {
        List<Stock> Extract(string fileName);
    }
}