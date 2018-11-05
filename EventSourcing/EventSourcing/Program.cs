using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    class Program
    {
        static void Main(string[] args)
        {
           OrderCommandHandler orderCOmmandHandler = new OrderCommandHandler();

            orderCOmmandHandler.Handle( new AddOrder());

        }
    }

    public interface ICommand
    {

    }

    public class AddOrder : ICommand
    {

    }

    public class CancelOrder : ICommand
    {

    }

    public class ApproveOrder : ICommand
    {

    }


    public interface ICommandHandler<ICommand>
    {
        void Handle(ICommand command);
    }

    public class OrderCommandHandler :
        ICommandHandler<AddOrder>,
        ICommandHandler<CancelOrder>,
        ICommandHandler<ApproveOrder>
    {
        public void Handle(AddOrder command)
        {
            throw new NotImplementedException();
        }

        public void Handle(CancelOrder command)
        {
            throw new NotImplementedException();
        }

        public void Handle(ApproveOrder command)
        {
            throw new NotImplementedException();
        }
    }
    
}
