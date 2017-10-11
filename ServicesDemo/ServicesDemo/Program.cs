using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Constants
    {
        public static Guid TestGuid = Guid.Parse("D1B3A24E-F6AA-4E39-BE6C-AAE43F04DEEE");
    }

    class Program
    {
        static void Main(string[] args)
        {
            var persons = PersonGenerator.CreatePersons(10);
            PersonService svc = new PersonService(persons);
            var persons1 = svc.GetPersons();
            foreach (Person currentPerson in persons1)
            {
                Console.WriteLine($"{currentPerson.Id} {currentPerson.FirstName} {currentPerson.LastName}");
            }
        }
    }

    public class PersonService
    {
        private List<Person> _persons = new List<Person>();
        public PersonService(List<Person> persons)
        {
            if (persons != null)
                _persons = persons;
            else
            {
                string firstName = "Richard";
                string lastName = "Jones";
                _persons.Add(new Person(Guid.NewGuid(), firstName, lastName));
            }
        }

        public void AddPerson(Person newPerson)
        {
            _persons.Add(newPerson);
        }

        public List<Person> GetPersons()
        {
            return _persons;
        }

        public Person GetPerson(string id)
        {
            return _persons.Find(x=>x.Id.Equals(id));
        }
    }

    public class Person
    {
        
        [Key]
        public  Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public Person(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
