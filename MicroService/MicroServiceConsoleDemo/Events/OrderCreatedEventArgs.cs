using System;

namespace ConsoleApp1.Events
{
    public class OrderCreatedEventArgs : EventArgs
    {
        public DateTime Created { get;set; }
        public OrderCreatedEventArgs()
        {
            this.Created = DateTime.Now;
        }
    }
}