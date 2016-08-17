namespace BuilderPattern
{
    public abstract class SandwichBuilder
    {
        protected Sandwich sandwich;


        public Sandwich GetSandwich()
        {
            return sandwich;
        }
        public void CreateSandwich()
        {
            sandwich = new Sandwich();
           
        }
        public abstract void ApplyMeatAndCheese();
        public abstract void PrepareBread();
        public abstract void AddCondiments();
        public abstract void ApplyVegtables();
    }
}