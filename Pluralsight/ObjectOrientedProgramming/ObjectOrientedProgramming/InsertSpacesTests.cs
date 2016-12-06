using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ObjectOrientedProgramming
{
    [NUnit.Framework.TestFixture]
     public class InsertSpacesTests
    {
        [Test]
        public void InsertSpacesTest()
        {
            var source = "SonicScrewdriver";
            var result = Helper.InsertSpace(source);
            var expectedResult = "Sonic Screwdriver";
            Assert.IsTrue(expectedResult.Equals(result.ToString()));

        }


        [Test]
        public void InsertSpacesTestWithSpace()
        {
            var source = "Sonic Screwdriver";
            var result = Helper.InsertSpace(source);
            var expectedResult = "Sonic Screwdriver";
            Assert.IsTrue(expectedResult.Equals(result.ToString()));

        }

        [Test]
        public void InsertSpacesTestWithSpaceAndSpace()
        {
            var source = "Sonic ScrewDriver";
            var result = Helper.InsertSpace(source);
            var expectedResult = "Sonic Screw Driver";
            Assert.IsTrue(expectedResult.Equals(result.ToString()));

        }


        [Test]
        public void InsertSpacesTestWithSpaceAndSpaceUsingExtensionMethod()
        {
            var source = "Sonic ScrewDriver";
            var result = source.InsertSpaceWithCapitalSeparator();
            var expectedResult = "Sonic Screw Driver";
            Assert.IsTrue(expectedResult.Equals(result.ToString()));

        }

        [Test]
        public void NoSpaceToInsertWithNoCapitals()
        {

            //Arrange

            // Act


            //Assert

            var source = "Hot";
            var expected = "Hot";

            string result = Helper.InsertSpace(source);
            Assert.IsTrue(expected.Equals(result));
        }

        [Test]
        public void NoSpaceToInsertWithSpace()
        {
            var source = "Hot Sauce";
            var expected = "Hot Sauce";

            string result = Helper.InsertSpace(source);
            Assert.IsTrue(expected.Equals(result));
        }

        
    }
}
