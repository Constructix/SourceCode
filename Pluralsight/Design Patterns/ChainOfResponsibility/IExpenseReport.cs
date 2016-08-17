using System;

namespace ChainOfResponsibility
{
    public interface IExpenseReport
    {
        Decimal Total { get; }
    }

    public class ExpenseReport : IExpenseReport
    {
        public ExpenseReport()
        {
            
        }

        public ExpenseReport(decimal total)
        {
            this.Total = total;
        }

        public decimal Total { get; }
    }
}