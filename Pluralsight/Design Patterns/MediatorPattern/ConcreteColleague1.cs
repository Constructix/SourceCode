using System;

namespace MediatorPattern
{
    public class ConcreteColleague1 : BaseColleague
    {
        public ConcreteColleague1()
        {
        }

        public ConcreteColleague1(BaseMediator mediator) : base(mediator)
        {


        }

        public override void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public override void Notifiy(string message)
        {
            Console.WriteLine($"Colleague 1 gets Message: {message}");
        }
    }
}