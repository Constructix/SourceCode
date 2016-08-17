using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {

           ExpenseHandler william = new ExpenseHandler(new Employee("William Worker", 0m));
            ExpenseHandler mary = new ExpenseHandler(new Employee("Mary", 1000m));
            ExpenseHandler victor = new ExpenseHandler(new Employee("victor", 5000m));
            ExpenseHandler paula = new ExpenseHandler(new Employee("Paula", 20000m));

            william.RegisterNext(mary);
            mary.RegisterNext(victor);
            victor.RegisterNext(paula);

            decimal expenseReportAmount;

            expenseReportAmount = GetExpenseReportAmount();
            while (expenseReportAmount > -1)
            {
                IExpenseReport expense = new ExpenseReport(expenseReportAmount);
                ApprovalResponse response = william.Approve(expense);
                Console.WriteLine($"Request was {response}.");
                expenseReportAmount = GetExpenseReportAmount();
            }
        }

        private static decimal GetExpenseReportAmount()
        {
            decimal expenseReportAmount;
            Console.WriteLine("Expense Report Amount:");
            decimal.TryParse(Console.ReadLine(), out expenseReportAmount);
            return expenseReportAmount;
        }
    }
}
