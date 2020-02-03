using Shouldly;
using Xunit;

namespace WatchListAnalysis.Tests
{
    public class StockTests
    {
        [Fact]
        public void InstanceCreated_NotNullReturned()
        {
            IStock stock = new Stock() { Code = "GXY"};
            stock.Code.ShouldBe("GXY");

        }
    }
}