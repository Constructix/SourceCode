using System;

namespace BridgePattern
{
    public class ClientRequest : Request
    {

        public ClientRequest(ILog log) : base(log)
        {
            
        }

        public override void Log()
        {
            Logger.LogMessage("In Client Request");
        }

        public Guid Id { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}