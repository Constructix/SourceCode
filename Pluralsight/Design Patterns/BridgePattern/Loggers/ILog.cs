namespace BridgePattern
{
    public interface ILog
    {
        string FileName { get; set; }
        void LogMessage(string messageToLog);
    }
}