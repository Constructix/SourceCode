using System;

namespace BehaviourDesignPattern.Behaviours
{
    public class MuteBehaviour : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("MUTE......");
            
        }
    }
}