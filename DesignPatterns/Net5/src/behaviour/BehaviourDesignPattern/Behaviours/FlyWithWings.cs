using System;

namespace BehaviourDesignPattern.Behaviours
{
    public class FlyWithWings : IFlyBehaviour
    {
        public void Fly() => Console.WriteLine("FLYING .......");
       
    }
}