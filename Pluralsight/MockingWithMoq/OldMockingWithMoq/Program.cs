using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace MockingWithMoq
{
    [TestFixture]
    public class MockingClass
    {
        [Test]
        public void Repository_Save_Should_be_Called()
        {
            //Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            var customerService = new CustomerService(mockRepository.Object);

            // Act
            customerService.Create(new CustomerToCreateDto() { FirstName = "Richard", LastName = "Jones"});
            //Assert
            mockRepository.VerifyAll();
        }

        [Test]
        public void Exception_Should_be_Thrown_ifAddress_is_not_created()
        {
            // Arrange
            var customerToCreateDto = new CustomerToCreateDto() {FirstName = "Bob", LastName = "Builder"};
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerToCreateDto>())).Returns(()=>null);


            var customerService = new CustomerService(mockAddressBuilder.Object, mockCustomerRepository.Object);
            // act
            Assert.Throws<InvalidOperationException>(() => customerService.Create(customerToCreateDto));
            // assert
			
			
			Console.WriteLine("HERE in Exception");


        }

        [Test]
        public void Exception_Should_be_Thrown_ifAddress_is_Created()
        {
            // Arrange
            var customerToCreateDto = new CustomerToCreateDto() { FirstName = "Bob", LastName = "Builder" };
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
                                            .Returns(() => new Address());


            var customerService = new CustomerService(mockAddressBuilder.Object, mockCustomerRepository.Object);
            // act
            customerService.Create(customerToCreateDto);
            // assert
            mockCustomerRepository.Verify(y=>y.Save(It.IsAny<Customer>()));

        }


        [Test]
        public void CustomerRepository_Should_be_called_once_perCustomer()
        {

            //Arrange
            var listOfCustomerDtos = new List<CustomerToCreateDto>
            {
                new CustomerToCreateDto() { FirstName = "Sam", LastName = "Sampson"},
                new CustomerToCreateDto() { FirstName = "Bob", LastName = "Builder"},
                new CustomerToCreateDto() { FirstName = "Doug", LastName = "Digger"},

            };
          
            var mockCustomerRepository = new Mock<ICustomerRepository>();


            var customerService = new CustomerService( 
                                                        mockCustomerRepository.Object);
            //Act
            customerService.Create(listOfCustomerDtos);
            //Assert
            mockCustomerRepository.Verify(x=>x.Save(It.IsAny<Customer>()),Times.Exactly(listOfCustomerDtos.Count));
        }

        
    }
}
