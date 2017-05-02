using System;

namespace PipelineDesignPattern.Tests
{
    public class ConcretePipelineHandler : BasePipelineHandler
    {
        public override void Process(BaseCommand cmd)
        {
            cmd.ExecutedOn = DateTime.Now;
        }
    }
}