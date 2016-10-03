using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LambdasAndDelegates
{

    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            var data = new ProcessData();
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate addMultiply = (x, y) => x*y;

            //data.Process(2,3, addDel);
            //DemostrationOfActionOfT(data);

            //DemostrationOfFuncOfT(data);

            HowToUseLambdasWithCollections();
        }

        private static void HowToUseLambdasWithCollections()
        {
            var customers = new List<Customer>
            {
                new Customer {City = "Phoenix", FirstName = "John", LastName = "Doe", Id = 1},
                new Customer {City = "Phoenix", FirstName = "Jane", LastName = "Doe", Id = 500},
                new Customer {City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", Id = 3},
                new Customer {City = "New York City", FirstName = "Michelle", LastName = "Smith", Id = 4}
            };

            var phoCust = customers
                .Where(c => c.City.Equals("Phoenix") && c.Id < 500)
                .OrderBy(c => c.FirstName);

            foreach (Customer customer in phoCust)
            {
                Console.WriteLine(customer.FirstName);
            }
        }

        private static void DemostrationOfFuncOfT(ProcessData data)
        {
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x*y;

            data.ProcessFunc(2, 3, funcAddDel);
            data.ProcessFunc(2, 3, funcMultiplyDel);
        }

        private static void DemostrationOfActionOfT(ProcessData data)
        {
            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x*y);

            data.ProcessAction(2, 3, myAction);
            data.ProcessAction(2, 3, myMultiplyAction);
        }
    }

    public class Customer
    {
        public int  Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
