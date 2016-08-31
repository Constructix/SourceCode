using System;

namespace Automobiles_02
{


    public class MiniCooper : AutomobileBase
    {

        public MiniCooper()
        {
            this.Name = "mini Cooper";
            this.Id = Guid.Parse("5C163E08-4577-493C-BD0B-4C7F8C524B7F");
        }
        public override Guid Id { get; }
        public override string Name { get; }
        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }

    internal class Bmw335Xi : AutomobileBase
    {

        public Bmw335Xi()
        {
            this.Name = "BMW335XI";
            this.Id = Guid.Parse("5FA72097-F603-44BD-A709-3EA42091B74B");
        }

        public override Guid Id { get; }
        public override string Name { get; }

        public override void Start()
        {
            Console.WriteLine($"{Name} started.");
        }

        public override void Stop()
        {
            Console.WriteLine($"{Name} stopped.");
        }
    }
}