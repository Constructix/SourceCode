using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CommandDesignPattern
{
    [TestFixture]
    public class CommandUnitTests
    {
        [Test]
        public void CommandsCreated()
        {
            BaseCommand BaseCommand = new ConcreteBaseCommand();
            Assert.That(BaseCommand != null);
        }

        [Test]
        public void simulateClient()
        {
            IReceiver receiver = new Receiver() {Message = "this is from receiver"}; // this is where the actual work gets done.
            IReceiver receiver2 = new UpperCaseReceiver { Message = "This is from the UpperCaseReceiver"};
            BaseCommand command = new ConcreteBaseCommand();
            Invoker invoker = new Invoker();

            command.SetReceiver(receiver);
            command.SetReceiver(receiver2);

            invoker.SetCommand(command);

            invoker.ExecuteCommand();
        }

    }
}
