using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class PersonGenerator
    {
        public static List<Person> CreatePersons(int numberOfPersonsToCreate)
        {
            string [] names     = new string[] {"Richard", "Peter", "Paul", "John", "Rex", "Ted"};
            string [] lastNames = new string[] {"Jones", "Williams", "Simpson", "Jennings"};

            List<Person> persons = new List<Person>();
            Random r = new Random();
            for (int index = 0; index < numberOfPersonsToCreate; index++)
            {
                string firstName = names[r.Next(0, names.Length - 1)];
                string lastName = lastNames[r.Next(0, lastNames.Length - 1)];
                persons.Add(new Person(id:Guid.NewGuid(), firstName:firstName, lastName:lastName));
            }
            return persons; 
        }
    }
}