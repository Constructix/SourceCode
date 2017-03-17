using Xunit;
using Xunit.Abstractions;

namespace PipelineDesignPattern.Tests
{
    public abstract class BaseTest
    {
        protected readonly ITestOutputHelper _helper;

      

        protected BaseTest(ITestOutputHelper helper)
        {
            _helper = helper;
        }
        [Fact]
        public abstract void InstanceIsNotNull();

    }
}