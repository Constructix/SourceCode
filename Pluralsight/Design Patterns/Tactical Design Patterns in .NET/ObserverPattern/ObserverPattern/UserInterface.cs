using System;
using System.Runtime.Remoting;

namespace ObserverPattern
{
    public class UserInterface
    {

        public readonly IObserver<string> AfterDoSomethingWith;

        public UserInterface()
        {
            this.AfterDoSomethingWith = 
                new NotificationSink<string>((sender, data) => this.AfterDoSomethingWithHandler(sender, data));
        }

        public void AfterDoSomethingWithHandler(object subject, string data)
        {
            Console.WriteLine($"Hey user, look at {data.ToUpper()}");
        }
    }
}