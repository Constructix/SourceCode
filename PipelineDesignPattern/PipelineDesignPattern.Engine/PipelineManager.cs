using System.Collections.Generic;

namespace PipelineDesignPattern.Engine
{
    public class PipelineManager
    {
        public List<IHandler> Handlers { get; set; }


        public PipelineManager()
        {
            Handlers  = new List<IHandler>();
        }

        public void Execute(Command cmd)
        {
            foreach (IHandler handler in Handlers)
            {
                handler.Process(cmd);
            }
        }
    }
}