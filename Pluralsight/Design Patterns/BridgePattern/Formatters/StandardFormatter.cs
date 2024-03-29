﻿namespace BridgePattern
{
    public class StandardFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return string.Format($"{key}: {value}");
        }
    }
}