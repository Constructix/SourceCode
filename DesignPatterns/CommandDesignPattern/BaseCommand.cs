namespace CommandDesignPattern
{
    public class BaseCommand
    {
        protected IReceiver Receiver { get; set; }
        public void SetReceiver(IReceiver receiver)
        {
            this.Receiver = receiver;
        }

        public virtual void Execute()
        {
            
        }

        public BaseCommand()
        {
            
        }

        public BaseCommand(IReceiver receiver)
        {
            this.Receiver = receiver;
        }
    }
}