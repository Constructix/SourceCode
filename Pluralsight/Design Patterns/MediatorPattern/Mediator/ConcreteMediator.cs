namespace MediatorPattern
{
    public class ConcreteMediator : BaseMediator
    {

        public ConcreteColleague1 Colleague1 { get; set; }
        public ConcreteColleague2 Colleague2 { get; set; }

        public ConcreteMediator()
        {
        }

        public override void Send(string message, BaseColleague concreteColleague1)
        {
            if(concreteColleague1 is ConcreteColleague1)
                Colleague2.Notifiy(message);
            if(concreteColleague1 is ConcreteColleague2)
                Colleague1.Notifiy(message);
        }
    }
}