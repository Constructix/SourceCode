using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class Customer
    {
        [Key]
        public string Email { get;  }

        public Customer(string rJonesConstructixComAu) { }

        public Customer(string email, bool hasCredit, decimal creditAvailable)
        {
            this.Email = email;
          
        }
    }

    public class CustomerFinancial
    {
        public virtual  Customer Customer {get;}
        public bool HasCredit { get; }
        public decimal CreditAvailable { get; }

        public CustomerFinancial(Customer customer,decimal creditAvailable, bool hasCredit )
        {
            CreditAvailable = creditAvailable;
            HasCredit = hasCredit;
            Customer = customer;
        }
    }
}