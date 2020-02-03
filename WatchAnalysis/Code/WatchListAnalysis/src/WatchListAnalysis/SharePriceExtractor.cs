using System.Collections.Generic;
using System.IO;

namespace WatchListAnalysis
{
    public class SharePriceExtractor : ISharePriceExtractor
    {
        const string SearchForText = "-- DELETE THIS LINE AND ABOVE, SAVE AS TEXT FILE THEN IMPORT --";

        public List<Stock> Extract(string fileName)
        {
            List<Stock> stocks = new List<Stock>();
            bool searchForTextEncountered = false;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var currentLine = reader.ReadLine();
                        if (currentLine.Equals(SearchForText))
                        {
                            currentLine = reader.ReadLine();
                            searchForTextEncountered = true;
                        }

                        if (searchForTextEncountered)
                        {
                            stocks.Add(StockBuilder.Create(currentLine));
                        }
                    }
                }
            }
            return stocks;
        }
    }
}