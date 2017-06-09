using System;

namespace ObserverPattern
{
    public class Logger: IObserver
    {
        public void AfterDoSomethingWith(ISubject subject, string data)
        {
            Console.WriteLine($"Writing down {data.ToUpper()}");
        }

        public void AfterDoMore(ISubject sender, string completeData, string appendData)
        {
            Console.WriteLine($"Writing down appended {appendData.ToUpper()}");
        }
    }
}