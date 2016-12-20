using System;

namespace BridgeDesignPattern
{
    public class ConcreteImplementorB : IBaseImplementor
    {
        public void OperationImp()
        {
            Console.WriteLine("In ConcreteImplementor B");
        }
    }
}