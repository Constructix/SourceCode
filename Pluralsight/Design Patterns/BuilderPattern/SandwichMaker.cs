using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class SandwichMaker
    {
        private readonly SandwichBuilder builder;

        public SandwichMaker(SandwichBuilder builder)
        {
            this.builder = builder;
        }

        public Sandwich GetSandwich()
        {
            return builder.GetSandwich();
        }
        public void BuildSandwich()
        {
            builder.CreateSandwich();
            builder.PrepareBread();
            builder.ApplyMeatAndCheese();
            builder.ApplyVegtables();
            builder.AddCondiments();
        }
    }
}
