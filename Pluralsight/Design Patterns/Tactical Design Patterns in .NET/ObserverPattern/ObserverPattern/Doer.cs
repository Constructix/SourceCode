using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class Doer : ISubject
    {
        readonly List<IObserver> _observers = new List<IObserver>();


        private string data = string.Empty;


        public void DoSomethingWith(string data)
        {
            this.data = data;
            this.AfterDoSomethingWith(this.data);
        }


        public void DoMore(string appendData)
        {
            this.data += appendData;
            AfterDoMore(this.data, appendData);
        }

        public void AfterDoMore(string completeData, string appendData)
        {
            foreach (IObserver observer in this._observers)
            {
                observer.AfterDoMore(this, completeData, appendData);
            }
        }

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver Observer)
        {
           this._observers.Remove(Observer);
        }

        public void AfterDoSomethingWith(string data)
        {
            foreach (IObserver observer in this._observers)
            {
                observer.AfterDoSomethingWith(this, data);
            }
        }
    }
}