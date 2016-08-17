namespace BridgePattern
{
    public class SupplierRequest : Request
    {

        public SupplierRequest(ILog logger) : base(logger)
        {
            
        }

        public override void Log()
        {
            Logger.LogMessage("In SupplierRequest");
        }

        public string Id { get; set; }
    }
}