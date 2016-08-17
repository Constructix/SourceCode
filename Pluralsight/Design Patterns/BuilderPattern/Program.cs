using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ClubSandwichBuilder();

            SandwichMaker maker = new SandwichMaker(builder);
            maker.BuildSandwich();
            var sandwich = maker.GetSandwich();
            sandwich.Display();
        }
    }
}
