namespace MockingDemo
{
    public interface ICustomerFactoryInputData : IFactoryInputData
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
    }
}