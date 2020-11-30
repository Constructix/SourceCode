using System;

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
    public interface IQuackBehaviour
    {
        public void Quack();
    }
    public class QuackBehaviour : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("QUACK.....");
        }
    }

    public class SqueakBehaviour : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("SQUEAK.....");
            
        }
    }
    public class MuteBehaviour : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("MUTE......");
            
        }
    }
    #endregion    
    
    #region Fly

    public interface IFlyBehaviour
    {
        public void Fly();
    }
    
    public class FlyWithWings : IFlyBehaviour
    {
        public void Fly() => Console.WriteLine("FLYING .......");
       
    }
    
    public class FlyNoWings :IFlyBehaviour
    {
        public void Fly() => Console.WriteLine("NOT FLYING......");
    }

    #endregion
}
