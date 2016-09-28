using System;

namespace StaticVariablesDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Manager mgr = new Manager();
            mgr.DoSomeWork();
            mgr.DoSomeWork();
        }
    }

    public class Manager
    {
        public int VisitsToThisMethod { get; set; }
        public void DoSomeWork()
        {

            ++VisitsToThisMethod;
            Console.WriteLine($"Number of Visits {VisitsToThisMethod}");
        }
    }
}
