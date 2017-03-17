using Xunit;
using Xunit.Abstractions;

namespace PipelineDesignPattern.Tests
{
    public class PipelineManagerTests : BaseTest
    {
        private PipelineManager _pipeLineManager;
        public PipelineManagerTests(ITestOutputHelper helper) : base(helper)
        {
            _pipeLineManager = new PipelineManager();
        }

        [Fact]
        public override void InstanceIsNotNull()
        {
            Assert.NotNull(_pipeLineManager);
            _helper.WriteLine("PipleLineManager is Not Null");
        }

        [Fact]
        public void HandlersIsNotNull()
        {
            Assert.NotNull(_pipeLineManager.Handlers);
            _helper.WriteLine("Handlers is not null");
        }

        [Fact]
        public void AddCommandToPipeLineManager()
        {
            string expectedValue = "11 CARBINE COURT";
            Command cmd = new Command() {Title = "This is a test for command"};

           _pipeLineManager.Handlers.Add( new ConcreteHandler1());
           _pipeLineManager.Handlers.Add(new UpperCaseHandler());

            _pipeLineManager.Execute(cmd);
            _helper.WriteLine(cmd.Title);
            Assert.True(expectedValue.Equals(cmd.Title));
        }
    }



}