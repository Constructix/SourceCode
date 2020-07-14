<Query Kind="Program" />

void Main()
{
	List<Person> persons = new List<Person>() { 
								new Person { FirstName = "Richard", LastName = "Jones" }, 
								new Person { FirstName = "Ted", LastName = "Williams" }
								};
	
	persons.ForEach(p => Console.WriteLine( p.ToCsv()));
	
	
}

public class Person
{
	public string FirstName {get;set;}
	public string LastName {get;set;}
	public string ToCsv() =>  $"{this.FirstName},{this.LastName}";
	
}