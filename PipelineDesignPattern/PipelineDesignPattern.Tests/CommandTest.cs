using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipelineDesignPattern.Engine;
using Xunit;
using Xunit.Abstractions;

namespace PipelineDesignPattern.Tests
{
    public class CommandTest : BaseTest
    {
        private Command _command;


        public CommandTest(ITestOutputHelper helper) : base(helper)
        {
            
        }
        [Fact]
        public override void InstanceIsNotNull()
        {
            _command = new Command();
            Assert.NotNull(_command);
        }

        [Fact]
        public void AddTitle()
        {
            _command = new Command() { Title = "This is the title"};
            Assert.False(string.IsNullOrWhiteSpace(_command.Title));
        }
    }
}
