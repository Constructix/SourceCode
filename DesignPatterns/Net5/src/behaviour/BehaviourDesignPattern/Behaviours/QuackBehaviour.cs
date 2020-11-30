using System;

namespace BehaviourDesignPattern.Behaviours
{
    public class QuackBehaviour : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("QUACK.....");
        }
    }
}