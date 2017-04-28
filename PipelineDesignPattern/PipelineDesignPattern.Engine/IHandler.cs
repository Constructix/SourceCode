namespace PipelineDesignPattern.Engine
{
    public interface IHandler
    {
        void Process(Command command);
    }
}