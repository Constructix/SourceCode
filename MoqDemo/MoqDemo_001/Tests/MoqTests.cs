using System;
using System.Runtime.CompilerServices;
using Moq;
using Shouldly;

namespace MoqDemo_001
{
    public class MoqTests
    {
        [Xunit.Fact]
        public void Test()
        {
            var mock = new  Mock<IFoo>();
            mock.SetupProperty(setup => setup.Name, "Richard");
           
            IFoo foo = mock.Object;
            var actualName = foo.Name;
            string expectedName = "Richard";
            actualName.ShouldBe(expectedName);

        }

    }

}
