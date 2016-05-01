using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StrayaGaming.Data;
using StrayaGaming.Contracts;
using StrayaGaming.Ban.Tests;

namespace StrayaGaming.Ban.Tests
{
    [TestFixture]
    public class ServerTests
    {
        [Test]
        public void ServerInstanceCreatedNoExceptionExpected()
        {
            IServer server = new Server();
            Assert.That(server!=null);
        }

        [Test]
        public void ServerNameIsSetAndNotNullOrEmptyNoExceptionExpected()
        {
            string expectedServerName = "Invade & Annexe";
            IServer server = new Server {Name = "Invade & Annexe"};
            Assert.That(server.Name.Equals(expectedServerName));
        }

        [Test]
        public void ServerNameIpAddressIsSetNoExceptionExpected()
        {
            string expectedIpAddress = "45.121.211.26";
            IServer serve = new Server {Address = "45.121.211.26"};
            Assert.That(serve.Address.Equals(expectedIpAddress));
        }

        [Test]
        public void ServerPortNumberIsAssignedNoExceptionExpected()
        {
            string expectedPortNumber = "2882";
            IServer Server = new Server {Port = "2882"};
            Assert.That(    Server.Port.Equals(expectedPortNumber));
        }

    }
}
