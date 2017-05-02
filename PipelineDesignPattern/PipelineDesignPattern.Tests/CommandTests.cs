using Xunit;

namespace PipelineDesignPattern.Tests
{
    public class CommandTests
    {
        public CommandTests()
        {
        }

        [Fact]
        public void CommandInstanceNotNull()
        {
            var cmd = new OrderCommand();
            Assert.NotNull(cmd);
        }

        [Fact]
        public void AddPersonToCommand()
        {
            var newPerson = new Person() {FirstName = "Richard"};
            var cmd  = new BaseCommand(newPerson);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
    }
}