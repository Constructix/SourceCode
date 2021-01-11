using System;

namespace BehaviourDesignPattern.Behaviours
{
    public class SqueakBehaviour : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("SQUEAK.....");
            
        }
    }
}