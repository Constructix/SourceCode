using System.Net.Mail;

namespace MockingWithMoq
{
    public interface ICustomerAddressBuilder      
    {
        MailAddress From(CustomerToCreateDto customerToCreateDto);
    }

    class CustomerAddressBuilder : ICustomerAddressBuilder
    {
        public MailAddress From(CustomerToCreateDto customerToCreateDto)
        {
            return new MailAddress(customerToCreateDto.EmailAddress);
        }
    }
}