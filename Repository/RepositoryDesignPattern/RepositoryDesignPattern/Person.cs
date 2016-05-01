using System;

namespace RepositoryDesignPattern
{
    public class Person : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public Person()
        {
            Created = DateTime.Now;
        }
    }


    
}