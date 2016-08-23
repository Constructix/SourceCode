using System;
using System.Diagnostics;
using Constructix.Business.Utilities;
namespace Test
{
	public class MainDriver
	{
		public static void Main()
		{

            Stopwatch watch = new Stopwatch();
		    watch.Start();
		    Console.WriteLine(string.Format("Date and Time : {0}",DateTime.Now.ToString()));

			Console.WriteLine("In Main");
			var emp = new Employee { FirstName = "Richard", LastName ="Jones"};
			Console.WriteLine(emp.FirstName);
			Console.WriteLine();
			
			
			IReading  reading = new Reading();
			reading.Total();
			
			var ibm = new IBM();
			ibm.Total();
		    watch.Stop();

			TimeSpan elapsed = watch.Elapsed;
		    Console.WriteLine("Total Duration of application took: {0} milliseconds",elapsed.TotalMilliseconds) ;
			
			Console.WriteLine("Press <enter> to end.");
			Console.ReadLine();			
		}
	}	
	
	public class Employee :  Person
	{		
	}
	
	public class IBM : ICompany
	{
		public void Total()
		{
			Console.WriteLine();
			Console.WriteLine("In IBM.Total()");
			Console.WriteLine();
		}
	}
	
	 public class Reading : IReading
	 {
		 public void Total()
		 {
			Console.WriteLine();
			Console.WriteLine("\tin reading.total()");
			Console.WriteLine();
		 }
	 }
}