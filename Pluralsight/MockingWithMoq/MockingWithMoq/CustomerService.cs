﻿using System.Collections;
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
        public CustomerService( ICustomerRepository customerRepository)
        {
            _customerAddressBuilder = new CustomerAddressBuilder();
            _customerRepository = customerRepository;
        }

        public void Create(IEnumerable<CustomerToCreateDto> customersToCreate)
        {
            foreach (var customerToCreateDto in customersToCreate)
            {
                _customerRepository.Save(new Customer(customerToCreateDto.FirstName, customerToCreateDto.LastName));
            }
        }

        public void Create(CustomerToCreateDto customerToCreateDto)
        {
            var customer = BuildCustomerObjectFrom(customerToCreateDto);

            customer.MailAddress = _customerAddressBuilder.From(customerToCreateDto);
            if (customer.MailAddress == null)
                throw new InvalidCustomerMailingAddressException();

            _customerRepository.Save(customer);
        }

        private Customer BuildCustomerObjectFrom(CustomerToCreateDto customerToCreateDto)
        {
            return new Customer(customerToCreateDto.Name, customerToCreateDto.City);
        }
    }
}