namespace CommandDesignPattern
{
    public class Invoker
    {
        BaseCommand BaseCommand { get; set; }


        public Invoker()
        {
            BaseCommand = new ConcreteBaseCommand();
        }

        public void SetCommand(BaseCommand BaseCommand)
        {
            this.BaseCommand = BaseCommand;
        }
        public void ExecuteCommand()
        {
            BaseCommand.Execute();
        }
    }
}