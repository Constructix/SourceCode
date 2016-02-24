namespace CommandDesignPattern
{
    public class ConcreteBaseCommand : BaseCommand
    {
        public override void Execute()
        {

            this.Receiver.Action();
            //foreach (IReceiver receiver in Receiver)
            //{
            //    receiver.Action();
            //}
            
        }

        public ConcreteBaseCommand()
        {
            
        }

        public ConcreteBaseCommand(Receiver receiver) : base(receiver)
        {
            
        }
    }
}