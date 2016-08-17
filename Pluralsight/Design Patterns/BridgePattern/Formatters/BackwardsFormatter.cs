using System.Linq;

namespace BridgePattern
{
    public class BackwardsFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return string.Format($"{key}: {new string(value.Reverse().ToArray())}");
        }
    }
}