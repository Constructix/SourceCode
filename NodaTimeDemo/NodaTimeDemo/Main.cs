using System;
using NodaTime;

namespace NodaTimeDemo
{
    public class MainConsole
    {
        public static void Main()
        {
            Instant now = SystemClock.Instance.Now;
            Console.WriteLine(now.ToDateTimeUtc());
        }
        
    }
}