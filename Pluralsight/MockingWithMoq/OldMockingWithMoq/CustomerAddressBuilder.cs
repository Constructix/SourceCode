namespace MockingWithMoq
{
    public class CustomerAddressBuilder : ICustomerAddressBuilder
    {
        public Address From(CustomerToCreateDto customerToCreateDto)
        {
            return new Address();
        }
    }
}