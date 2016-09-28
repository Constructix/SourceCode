using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Constructix.Utilities.Tests
{
    [TestFixture]
    public class OperationResultTests
    {
        [Test]
        public void OperationResultInstanceCreated()
        {
            var result = new OperationalResult<int>();
            Assert.IsNotNull(result);
        }

        [Test]
        public void MessageIsSet()
        {
            var result = new OperationalResult<string>() {Message = "Testing"};
            Assert.IsTrue(result.Message.Equals("Testing"));
        }

        [Test]
        public void ResultIsIntReturns_0()
        {
            var result = new OperationalResult<int>() { Result = 1};
            Assert.IsTrue(result.Result == 1);
        }

    }
}
