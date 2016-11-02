namespace MockingWithMoq
{
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