using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFDemo
{
    class Program
    {

        private CompositionContainer _container;
        [Import(typeof(ICalculator))] public ICalculator Calculator;

        private Program()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }


        static void Main(string[] args)
        {
            Program p = new Program(); //Composition is performed in the constructor
            String s;
            Console.WriteLine("Enter Command:");
            while (true)
            {
                s = Console.ReadLine();
                Console.WriteLine(p.Calculator.Calculate(s));
            }
        }

        [Export(typeof(ICalculator))]
        class MySimpleCalculator : ICalculator
        {
            public string Calculate(string input)
            {
                return "Calculate";
            }
        }
    }

  
    public interface ICalculator
    {
        String Calculate(String input);
    }

    
}
