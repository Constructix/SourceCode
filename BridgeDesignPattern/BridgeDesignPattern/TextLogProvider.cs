using System;

namespace BridgeDesignPattern
{
    public partial class TextLogProvider : BaseLogProvider
    {
        public override void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}