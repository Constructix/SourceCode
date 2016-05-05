﻿using System;
using System.Linq;
using Xunit;

namespace RepositoryDesignPattern
{
    public class ConsoleRepository
    {
        public static void Main()
        {
            DatabaseContext _database = new DatabaseContext();
            PersonRepository<DatabaseContext> personRepository = new PersonRepository<DatabaseContext>(_database);

            Person newPerson = new Person
            {
                FirstName = "Richard",
                LastName = "Jones",
                Email = "r_jones@constructix.com.au"
            };


            AddPerson(personRepository, newPerson);
            AddPerson(personRepository,new Person() { Email = "t_jones@constructix.com.au", FirstName = "Teresa", LastName = "Jones"});

            _database.SaveChanges();
            PrintList(personRepository);
            // update person


            var modifiedPerson = personRepository.FindById("r_jones@constructix.com.au");
            modifiedPerson.FirstName = "Richard";
            personRepository.Update(modifiedPerson);
            Console.WriteLine();
            PrintList(personRepository);
        }

        private static void PrintList(PersonRepository<DatabaseContext> personRepository)
        {
            Console.WriteLine("List of Persons in Database");
            foreach (Person person in personRepository.List)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }

        private static void AddPerson(PersonRepository<DatabaseContext> personRepository, Person newPerson)
        {
            if (personRepository.FindById(newPerson.Email) == null)
            {
                personRepository.Add(newPerson);
            }
        }
    }
}