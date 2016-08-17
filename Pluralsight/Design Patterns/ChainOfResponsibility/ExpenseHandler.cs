using System;

namespace ChainOfResponsibility
{
    public class ExpenseHandler : IExpenseHandler
    {
        private readonly IExpenseApprover _approver;
        private IExpenseHandler _next;

        public ExpenseHandler(IExpenseApprover approver)
        {
            _approver = approver;
            _next = EndOfChainExpenseHandler.Instance;
        }

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            ApprovalResponse response = _approver.ApproveExpense(expenseReport);
            if (response == ApprovalResponse.BeyondApprovalLimit)
            {
                
                    return _next.Approve(expenseReport);
            }
            return response;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            this._next = next;
        }
    }

    public class EndOfChainExpenseHandler : IExpenseHandler
    {
        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            return ApprovalResponse.Denied;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            throw new InvalidOperationException("End of chain handler must be the end of the chain.");
        }

        public static EndOfChainExpenseHandler Instance
        {
            get { return _instance; }
        }

        private static readonly  EndOfChainExpenseHandler _instance = new EndOfChainExpenseHandler();
    }
}