namespace ClientBuildDemo
{
    using System;

    public static class MainConsole
    {
        public static void Main()
        {
            Console.WriteLine("In Main");


            var firstName = "Richard";
            var lastName = "Jones";
            var person = new Person(firstName, lastName);
            Console.WriteLine(person.ToString());


            var newOrder = new Order();

            Console.WriteLine(newOrder.InternalId);
        }
    }
}