using System;

namespace BridgeDesignPattern
{
    public class ConcreteImplementorA : IBaseImplementor
    {
        public void OperationImp()
        {
            Console.WriteLine("In ConcreteImplementor A");
        }
    }
}