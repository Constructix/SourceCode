using System;

namespace EventDemo
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base($"Order could not be deleted as the order Id does not exist.")
        {
        }
    }
}