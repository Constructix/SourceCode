namespace MediatorPattern
{
    public abstract class BaseColleague
    {
        protected  BaseMediator Mediator { get; set; }


        public abstract void Notifiy(string message);

        public abstract void Send(string message);

        public BaseColleague()
        {
            
        }

        public BaseColleague(BaseMediator mediator)
        {
            this.Mediator = mediator;
        }
    }
}