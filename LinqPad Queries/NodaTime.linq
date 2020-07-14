<Query Kind="Program">
  <NuGetReference>NodaTime</NuGetReference>
  <Namespace>NodaTime</Namespace>
</Query>

void Main()
{
	Console.WriteLine("-------- Noda Time Demo -----------");
	
	Instant now = SystemClock.Instance.GetCurrentInstant();
	
	ZonedDateTime nowInIzoUTC =  now.InUtc();
	
	Console.WriteLine(now);
	Console.WriteLine(nowInIzoUTC);
	

	var systemZone =  DateTimeZoneProviders.Tzdb.GetSystemDefault();

	Console.WriteLine(now.InZone(DateTimeZoneProviders.Tzdb.GetZoneOrNull(systemZone.ToString())).LocalDateTime);



	Console.WriteLine("using ClockService");
	
	var clockSvc = new ClockService();
	
	
	Console.WriteLine($"Current dateTime: {clockSvc.LocalDateTime}");
	Console.WriteLine(clockSvc.LocalDateTime.Date);
}

public interface IClockService
{
	DateTimeZone TimeZone {get;}
	
	LocalDateTime LocalDateTime {get;}
	
}

public class ClockService : IClockService
{
	
	public ClockService()
	{
		TimeZone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
	}
	public DateTimeZone TimeZone {get;}
	public LocalDateTime LocalDateTime =>  SystemClock.Instance.GetCurrentInstant().InZone(DateTimeZoneProviders.Tzdb.GetZoneOrNull(TimeZone.ToString())).LocalDateTime;
}

// Define other methods, classes and namespaces here
