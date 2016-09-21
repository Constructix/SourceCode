using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OutputViewer
{
    public class Program
    {
        public static void Main()
        {
            StandardCatalog  standardCatalog = new StandardCatalog();

            ISaveable saveable = new StandardCatalog();
            IPersistable persistable = new StandardCatalog();

            

            Console.WriteLine($"Standard Implementation{Environment.NewLine}");
            Console.WriteLine($"Concrete Class  : {standardCatalog.Save()}");
            Console.WriteLine($"ISaveable       : {saveable.Save()}");
            Console.WriteLine($"IPersistable    : {saveable.Save()}");

            Console.WriteLine($"Concrete Class : {standardCatalog.Save()}");
            Console.WriteLine( $"(ISaveable) Class : {(ISaveable) standardCatalog.Save()}");
            Console.WriteLine($"Concrete Class : { (IPersistable) standardCatalog.Save()}");

        }
    }
}
