using System;
using BehaviourDesignPattern;
using BehaviourDesignPattern.Behaviours;
using Xunit;

namespace Behaviour.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DuckInstanceCreatedAndQuckBehaviour`()
        {
            
            
            IQuackBehaviour quackBehaviour  = new SqueakBehaviour();
            IFlyBehaviour flyBehaviour = new FlyNoWings();

            var duck = new Duck(quackBehaviour, flyBehaviour);
            
            duck.PerformFly();
            
            
        }
    }
}
