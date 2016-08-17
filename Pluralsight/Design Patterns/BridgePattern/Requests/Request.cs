namespace BridgePattern
{
    public abstract class Request
    {

        protected readonly ILog Logger;

        public Request(ILog logger)
        {
            this.Logger = logger;
        }

        public virtual void Log()
        {
            
        }
    }
}