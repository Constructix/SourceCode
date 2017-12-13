using System.Collections.Generic;

namespace Constructix.Home.ElectricityReadingManagement.Command
{


    public class Receiver
    {
        public void Action()
        {
            
        }
    }


    public abstract class BaseInvoker
    {
        protected BaseCommand BaseCommand;

        public abstract void AddCommand(BaseCommand command);

        public abstract void Execute();
    }


    public class BillingServicesInvoker : BaseInvoker
    {
        public override void AddCommand(BaseCommand command)
        {
            BaseCommand = command;
        }

        public override void Execute()
        {
            BaseCommand.Execute();
        }
    }


    public class ReadingCalculatorServiceInvoker : BaseInvoker
    {
        public override void AddCommand(BaseCommand command)
        {
            BaseCommand = command;
        }

        public override void Execute()
        {
            BaseCommand.Execute();
        }
    }


    public abstract class BaseCommand
    {
        public abstract  void Execute();
    }


    public class BillingServicesCommand : BaseCommand
    {
        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}