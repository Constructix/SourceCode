using System;
using System.IO;
using WatchListAnalysis;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           WatchListAnalysis.WatchListAnalysis _watchListAnalysis = new WatchListAnalysis.WatchListAnalysis();
           var files = _watchListAnalysis.GetFiles(@"D:\CommSec\DataFiles");
           Console.WriteLine("Curent files in location: ");
           foreach (var currentFile in files)
           {
               FileInfo fi =new FileInfo(currentFile);
               Console.WriteLine($"{fi.Name}  Created: {fi.CreationTime}");

               ISharePriceExtractor sharePriceExtractor = new SharePriceExtractor();
               var companyPrices = sharePriceExtractor.Extract(currentFile);

               foreach (Stock companyPrice in companyPrices)
               {
                    Console.WriteLine($"\t{companyPrice.Code} {companyPrice.Low/100,8} {companyPrice.Volume}");

               }
            }
        }
    }
}
