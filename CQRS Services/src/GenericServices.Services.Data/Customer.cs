namespace GenericServices.Services.Models
{
    public class Customer : IEntity<int>
    {

        public int Id { get; set; }

        public string FirstName { get; }
        public string LastName { get; }

        public Customer()
        {
        }

        public Customer(int id, string firstName, string lastName)
        {
            this.Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public Customer( string firstName, string lastName)
        {
            
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}