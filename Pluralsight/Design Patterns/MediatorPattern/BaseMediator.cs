namespace MediatorPattern
{
    public abstract class BaseMediator
    {
        public abstract void Send(string message, BaseColleague concreteColleague1);

    }
}