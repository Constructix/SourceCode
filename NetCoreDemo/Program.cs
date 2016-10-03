using System;
using System.Globalization;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Testing Person instance");

            var p = new Person { FirstName = "Richard", LastName = "Jones"};

            Console.WriteLine(p);
            Console.WriteLine(p.Created);

            Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture.EnglishName);

        }
    }


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
