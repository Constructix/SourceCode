using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMaker maker = new SandwichMaker(new MySandwichBuilder());
            maker.BuildSandwich();
            var sandwich = maker.GetSandwich();
            sandwich.Display();
            Console.WriteLine();

            maker = new SandwichMaker(new ClubSandwichBuilder());
            maker.BuildSandwich();
            sandwich = maker.GetSandwich();
            sandwich.Display();

            maker = new SandwichMaker(new SuperSandwichBuilder());
            maker.BuildSandwich();
            sandwich = maker.GetSandwich();
            sandwich.Display();


        }
    }
}
