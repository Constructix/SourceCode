using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonBuilder()
                .FirstName("Richard")
                .LastName("Jones")
                .Build();
            
            Console.WriteLine(person.FirstName);
        }
    }

    public class PersonBuilder
        {
            private Person _person;
            private string _firstName;
            private string lastName;
            public PersonBuilder FirstName(string firstName)
            {
                this._firstName = firstName;
                return this;
            }

            public PersonBuilder LastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }

            public Person Build()
            {
                return new Person { FirstName = this._firstName, LastName = lastName} ;
            }
        }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}