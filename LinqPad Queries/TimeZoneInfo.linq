<Query Kind="Program" />

void Main()
{
	Console.WriteLine("TimeZone Demo");
	
	System.TimeZoneInfo tzi = TimeZoneInfo.Local;
	
	Console.WriteLine($"Local TimeZoneInfo : {tzi}");
	Console.WriteLine();
	
	
	var timeZoneInfo = TimeZoneInfo.GetSystemTimeZones();
	foreach (var currentTimeZoneInfo in timeZoneInfo)
	{
		Console.WriteLine(currentTimeZoneInfo.DisplayName);
	}
}

// Define other methods, classes and namespaces here
