using System;
using System.Collections.Generic;

namespace MockingWithMoq
{
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
            _customerAddressBuilder = new CustomerAddressBuilder();
        }


        public void Create(CustomerToCreateDto customerToCreateDto)
        {
            var customer = BuildCustomerObjectFrom(customerToCreateDto);


          

            //customer.MailingAddress = _customerAddressBuilder.From(customerToCreateDto);

            //if (customer.MailingAddress == null)
            //{
            //    throw new InvalidOperationException();
            //}

            //_customerRepository.Save(customer);
        }

        public void Create(IEnumerable<CustomerToCreateDto> customersToCreate)
        {
            foreach (var customerToCreateDto in customersToCreate)
            {
                _customerRepository.Save(BuildCustomerObjectFrom(customerToCreateDto));
            }
        }

        private Customer BuildCustomerObjectFrom(CustomerToCreateDto customerToCreateDto)
        {
            return new Customer(customerToCreateDto.FirstName, customerToCreateDto.LastName);
        }
    }
}