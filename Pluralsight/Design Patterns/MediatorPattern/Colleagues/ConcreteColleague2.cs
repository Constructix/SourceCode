using System;

namespace MediatorPattern
{
    public class ConcreteColleague2: BaseColleague
    {
        public ConcreteColleague2()
        {
        }

        public ConcreteColleague2(BaseMediator mediator ): base(mediator)
        {
            
        }

        public override void Notifiy(string message)
        {
            Console.WriteLine($"Colleague 2 gets Message: {message}");
        }

        public override void Send(string message)
        {
            Mediator.Send(message,this);
        }
    }
}