using System;

namespace ChainOfResponsibility
{
    public class Employee : IExpenseApprover
    {
        public string Name { get; set; }
        private readonly Decimal approvalLimit;
      
        public Employee(string name, decimal approvalLimit)
        {
            Name = name;
            this.approvalLimit = approvalLimit;

        }

        public ApprovalResponse ApproveExpense(IExpenseReport expenseReport)
        {
            return expenseReport.Total > approvalLimit
                ? ApprovalResponse.BeyondApprovalLimit
                : ApprovalResponse.Approved;
        }
    }
}