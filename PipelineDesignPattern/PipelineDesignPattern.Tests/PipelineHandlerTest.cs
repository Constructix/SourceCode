using Xunit;

namespace PipelineDesignPattern.Tests
{
    public class PipelineHandlerTest
    {

        private BasePipelineHandler _handler;

        [Fact]
        public void PipelineHandlerNotNull()
        {
            _handler = new ConcretePipelineHandler();
            Assert.NotNull(_handler);
        }

        [Fact]
        public void ProcessProcessesCommandObject()
        {

            BaseCommand cmd = new BaseCommand();
            _handler =new ConcretePipelineHandler();

            _handler.Process(cmd);

            Assert.True(cmd.ProcessedDateTime.HasValue);

        }
    }
}