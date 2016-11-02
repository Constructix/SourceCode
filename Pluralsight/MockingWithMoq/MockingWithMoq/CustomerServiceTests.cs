using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace MockingWithMoq
{


    public class CustomerServiceTests
    {

        [TestFixture]
        public class When_creating_a_customer
        {

            [Test]
            public void an_exception_should_be_thrown_if_the_address_is_not_created()
            {
                // Arrange
                var customerToCreateDto = new CustomerToCreateDto {FirstName = "Bob", LastName = "Builder"};
                var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
                var mockCustomerRepository = new Mock<ICustomerRepository>();

                var customerService = new CustomerService(mockAddressBuilder.Object, mockCustomerRepository.Object);

                // Act
                
                // Assert

                Assert.Throws<InvalidCustomerMailingAddressException>(() => customerService.Create(customerToCreateDto));


            }


            [Test]
            public void the_repository_save__should_be_called()
            {
                // Arrange
                var mockRepository = new Mock<ICustomerRepository>();

                mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

                var customerService = new CustomerService(mockRepository.Object);

                // Act
                customerService.Create(new CustomerToCreateDto());

                // Assert
                mockRepository.VerifyAll();

            }

            [Test]
            public void the_customer_repository_should_be_called_once_per_customer()
            {
                // Arrange
                var listOfCustomerDtos = new List<CustomerToCreateDto>
                {
                    new CustomerToCreateDto {FirstName = "Same", LastName = "Sampson"},
                    new CustomerToCreateDto {FirstName = "Bob", LastName = "Builder"},
                    new CustomerToCreateDto {FirstName = "Doug", LastName = "Digger"}
                };

                var mockCustomerRepository = new Mock<ICustomerRepository>();

                
                var customerService = new CustomerService(mockCustomerRepository.Object);
                // Act
                customerService.Create(listOfCustomerDtos);
                // Assert
                mockCustomerRepository.Verify(x=>x.Save(It.IsAny<Customer>()),Times.Exactly(3));


            }
        }
    }
}