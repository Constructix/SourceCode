
using PersonLibrary;
using Xunit;

namespace TestVSTest
{
    
    public class PersonTest
    {

        [Fact]
        public void FirstName()
        {
            var person = new Person("Richard", "Jones");

            string expectedFirstName = "Richard";
            Assert.True(expectedFirstName.Equals(person.FirstName));
        }
    }

 
}