using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CarsView view = new CarsView(new CarRepository().GetAll());
            view.Render();
        }
    }
}
