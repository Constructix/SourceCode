using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace RulesPattern
{
   
    public interface IDiscountRule
    {
        decimal CalculateCustomerDiscount(Customer customer);
    }

    public class BirthdayDiscountRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            throw new NotImplementedException();
        }
    }

    public class Customer   
    {

        public DateTime DateOfBirth { get; set; }
    }
}
