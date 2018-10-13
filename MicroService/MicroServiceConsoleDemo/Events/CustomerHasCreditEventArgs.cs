using System;

namespace ConsoleApp1.Events
{
    public class CustomerHasCreditEventArgs : EventArgs
    {
        public Customer Customer { get; }
        public bool HasCredit {get;  }
        public decimal CreditAvailable { get; }

        public CustomerHasCreditEventArgs(Customer customer, bool hasCredit, decimal creditAvailable)
        {
            this.Customer = customer;
            this.HasCredit = hasCredit;
            this.CreditAvailable = creditAvailable;
        }
    }
}