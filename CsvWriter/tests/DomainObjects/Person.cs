using System;

namespace CsvWriter.Tests.DomainObjects
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        
        public Person() => Created = DateTime.Now;
    }
}