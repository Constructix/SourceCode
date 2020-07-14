<Query Kind="Program" />

/// <summary>Null coalacing operator Demo</summary>

void Main()
{	
	
	const string Firstname = "Richard";
	Person p = new Person(Firstname);
	p = null;
	p ??= new Person("William");
	Console.WriteLine(p.FirstName);
}

public class Person
{	
	string _firstName;
	public string FirstName => _firstName;	
	public Person(string firstName)
	{
		_firstName  =  firstName;
	}	
}