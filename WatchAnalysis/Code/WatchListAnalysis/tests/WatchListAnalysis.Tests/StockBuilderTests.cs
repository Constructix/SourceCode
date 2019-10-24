using Shouldly;
using Xunit;

namespace WatchListAnalysis.Tests
{
    public class StockBuilderTests
    {
        [Fact]
        public void Create_SingleLineCSV_ReturnsStockObjectInitialised()
        {
            var Stock = StockBuilder.Create("AMP,191022,177,182.7,176,180,17858882");

            Stock.ShouldNotBeNull();
            Stock.Code.ShouldBe("AMP");
            Stock.Low.ShouldBe(176.0m);
            Stock.Volume.ShouldBe(17858882);
        }
    }
}