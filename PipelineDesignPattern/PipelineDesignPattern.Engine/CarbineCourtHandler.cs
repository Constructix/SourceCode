namespace PipelineDesignPattern.Engine
{
    public class ConcreteHandler1 : IHandler
    {
      


        public ConcreteHandler1()
        {
            
        }

       

        public void Process(Command command)
        {


            command.Title = "11 carbine court";
            // command has been run.

        }
    }
}