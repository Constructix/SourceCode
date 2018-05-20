using System;

namespace ConsoleApp1.Events
{
    public class CustomerExistEventArgs : EventArgs
    {
        public DateTime Created { get; set; }
        public Customer Customer { get;set; }

        public CustomerExistEventArgs()
        {
            Created = DateTime.Now;
        }

        public CustomerExistEventArgs(Customer customer) : this()
        {
            this.Customer = customer;
        }
    }
}