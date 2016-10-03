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


    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressBuilder _customerAddressBuilder;

        public CustomerService(ICustomerAddressBuilder customerAddressBuilder, ICustomerRepository customerRepository)
        {
            _customerAddressBuilder = customerAddressBuilder;
            _customerRepository = customerRepository;
        }
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public void Create(CustomerToCreateDto customerToCreateDto)
        {
            var customer = new Customer(customerToCreateDto.FirstName, customerToCreateDto.LastName);


            customer.MailingAddress = _customerAddressBuilder.From(customerToCreateDto);

            if (customer.MailingAddress == null)
            {
                throw new InvalidOperationException();
            }

            _customerRepository.Save(customer);
        }

        public void Create(IEnumerable<CustomerToCreateDto> customersToCreate)
        {

            


            foreach (var customerToCreateDto in customersToCreate)
            {
                _customerRepository.Save(new Customer(customerToCreateDto.FirstName, customerToCreateDto.LastName));
            }
        }
    }

    public class CustomerToCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public interface ICustomerAddressBuilder
    {
        Address From(CustomerToCreateDto customerToCreateDto );
    }

    public class CustomerAddressBuilder : ICustomerAddressBuilder
    {
        public Address From(CustomerToCreateDto customerToCreateDto)
        {
            return new Address();
        }
    }

    public  class Address
    {
    }

    public interface ICustomerRepository    
    {
        void Save(Customer customer);
    }

    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName { get; set; }

        public string FirstName { get; set; }
        public Address MailingAddress { get; set; }
    }
}
