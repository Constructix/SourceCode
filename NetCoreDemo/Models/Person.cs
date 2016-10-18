using System;
namespace ConsoleApplication
{
  public class Person
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public DateTime Created {get;set;}
        public Person ()
        {
          Created = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName}");
        }
    }
}