namespace CommandDesignPattern
{
    public class ConcreteBaseCommand : BaseCommand
    {
        public override void Execute()
        {
            foreach (IReceiver receiver in Receiver)
            {
                receiver.Action();
            }
            
        }

        public ConcreteBaseCommand()
        {
            
        }

        public ConcreteBaseCommand(Receiver receiver) : base(receiver)
        {
            
        }
    }
}