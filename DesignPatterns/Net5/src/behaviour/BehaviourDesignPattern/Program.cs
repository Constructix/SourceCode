using System;
using BehaviourDesignPattern.Behaviours;

namespace BehaviourDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine(" ------  Behaviour Design Pattern Demonstration  ---------");

            Duck duck = new Duck(new QuackBehaviour(), new FlyWithWings());
            
            duck.PerformQuack();
            duck.PerformFly();
        }
    }

    public class Duck
    {

        public IQuackBehaviour _behaviour;
        public IFlyBehaviour _flyBehaviour;

        public Duck(IQuackBehaviour behaviour, IFlyBehaviour flyBehaviour)
        {
            _behaviour = behaviour;
            _flyBehaviour = flyBehaviour;
        }
        public void PerformQuack() => _behaviour.Quack();

        public void PerformFly() => _flyBehaviour.Fly();
    }
    
    
    // Behaviours
    #region Quack

    #endregion    
    
    #region Fly

    #endregion
}
