using System;
using System.Collections;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsDemo.Tests
{
    public class FluentAssertionsLearnTests
    {
        [Fact]
        public void FirstTest()
        {
            string actual = "ABCDEFGHI";

            actual.Should().StartWith("ABC").And.EndWith("HI");
        }

        [Fact]
        public void AssertWithNumbers()
        {
            var numbers = Enumerable.Range(0, 10);
            numbers.Should().StartWith(0).And.EndWith(9);

        }

    }
}
