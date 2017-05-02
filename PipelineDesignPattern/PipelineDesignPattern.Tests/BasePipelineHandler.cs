namespace PipelineDesignPattern.Tests
{
    public abstract class BasePipelineHandler
    {
        public abstract void Process(BaseCommand cmd);
    }
}