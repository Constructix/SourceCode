namespace PipelineDesignPattern.Engine
{
    public class CarbineCourtHandler : IHandler
    {
      


        public CarbineCourtHandler()
        {
            
        }

       

        public void Process(Command command)
        {
            command.Title = "11 carbine court";
        }
    }
}