using System;

namespace BehaviourDesignPattern.Behaviours
{
    public class FlyNoWings :IFlyBehaviour
    {
        public void Fly() => Console.WriteLine("NOT FLYING......");
    }
}