using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DatabaseContext() :base("name=RepositoryDemo")
        {
            
        }
    }
}
