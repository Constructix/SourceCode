using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Shouldly;
using Xunit;

namespace WatchListAnalysis.Tests
{
    public class SharePriceExtractorTests
    {
        private string _fileName;

        public SharePriceExtractorTests()
        {
            _fileName = "TestData.txt";
        }

        [Fact]
        public void GetStockPrice_TestDataSupplied_ReturnsFileContenttsShouldNotBeNull()
        {
           
            var fileContents = File.OpenText(_fileName);
            fileContents.ShouldNotBeNull();
        }

        [Fact]
        public void GetStockPrice_TestDataSupplier_ReturnsStockPrice()
        {
            ISharePriceExtractor  sharePriceExtractor = new SharePriceExtractor();
            var companyPrices = sharePriceExtractor.Extract(_fileName);
            companyPrices.FirstOrDefault()?.Code.ShouldBe("AMP");
            companyPrices.LastOrDefault()?.Code.ShouldBe("SUN");
        }
    }
}
