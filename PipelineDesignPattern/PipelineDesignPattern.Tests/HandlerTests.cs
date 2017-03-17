using PipelineDesignPattern.Engine;
using Xunit;
using Xunit.Abstractions;

namespace PipelineDesignPattern.Tests
{
    public class HandlerTests : BaseTest
    {
        private IHandler _handler;
        public HandlerTests(ITestOutputHelper helper) : base(helper)
        {
        }
        [Fact]
        public override void InstanceIsNotNull()
        {
            _handler = new CarbineCourtHandler();
            Assert.NotNull(_handler);
        }

        [Fact]
        public void ProcessProcessesCommandObject()
        {
            _handler = new CarbineCourtHandler();
            var cmd = new Command();

            _handler.Process(cmd);


        }
    }
}