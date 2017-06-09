using System.Collections;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class MulticastNotifier<T>
    {
        private IList<IObserver<T>> _observers;

        public MulticastNotifier(IList<IObserver<T>> observers)
        {
            this._observers = observers;
        }

        public void Notify(object sender, T data)
        {
            foreach (IObserver<T> observer in _observers)
            {
                observer.Update(sender, data);
            }
        }


        public void Attach(IObserver<T> observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(System.IObserver<T> observer)
        {
            this._observers.Remove(observer);
        }

    }
}