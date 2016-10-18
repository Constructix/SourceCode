using System.Collections.Generic;

namespace ConsoleApplication
{
public static class Helpers
{
      public static List<Person> InitialisePersonList()
        {
                return new List<Person>()
                                            {
                                                new Person { FirstName = "Richard", LastName ="Jones"},
                                                new Person { FirstName = "Douglas", LastName="Jones"},
                                                new Person { FirstName = "Teresa", LastName="Jones"},
                                                new Person { FirstName = "Georgia", LastName="Jones"}
                                            };
        }
}
}