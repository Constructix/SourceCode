using System;

namespace RepositoryUnitOfWorkDemo
{
    public static class NameGenerator
    {
        static readonly string[] _firstName = new string[]
        {
            "Richard", "Teresa",
            "Douglas", "Georgia",
            "Graeme", "Kay",
            "Kathryn", "Scott",
            "Rebecca", "Dylan",
            "Eva",
            "John", "Lachlan", "Tim",
            "Robert", "Diana", "Andrew", "Cara",
            "Madeline", "Hugo",
            "Geoffrey", "Jennifer",
            "Thomas", "Stacey",
            "Harry",
            "Kate", "Eliza",
            "Helen",
            "David", "Maria", "James", "Joshua", "Lucas",
            "Dorothy", "Alfred",
            "Neil"
        };

        static readonly string[] _lastName =  new string[]
        {
            "Jones", "Roach", "Williams", "Daily", "Page", "Jennings", "Dal Santo",
            "Walker", "Smith", "Armstrong", "Frost", "Willis", "Kent", "Mundy", "Dean"
        };


        static Random r = new Random(DateTime.Now.Millisecond);
        public static string NextName => _firstName[r.Next(0, _firstName.Length)];
        
        public static string LastName => _lastName[r.Next(0, _lastName.Length)];
    }
}