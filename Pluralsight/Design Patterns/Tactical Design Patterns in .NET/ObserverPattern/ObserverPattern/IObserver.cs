namespace ObserverPattern
{
    public interface IObserver
    {
        void AfterDoSomethingWith(ISubject subject, string data);
        void AfterDoMore(ISubject sender, string completeData, string appendData);
    }
}