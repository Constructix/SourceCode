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
            _handler = new ConcreteHandler1();
            Assert.NotNull(_handler);
        }

        [Fact]
        public void ProcessProcessesCommandObject()
        {
            _handler = new ConcreteHandler1();
            var cmd = new Command();

            _handler.Process(cmd);


        }
    }
}