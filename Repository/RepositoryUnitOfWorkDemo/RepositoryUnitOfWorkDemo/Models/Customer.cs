using System.ComponentModel.DataAnnotations;

namespace RepositoryUnitOfWorkDemo
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}