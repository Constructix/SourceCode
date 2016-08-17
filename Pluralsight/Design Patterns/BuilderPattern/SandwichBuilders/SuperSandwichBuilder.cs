namespace BuilderPattern
{
    public class SuperSandwichBuilder : SandwichBuilder
    {
        public override void ApplyMeatAndCheese()
        {
            this.sandwich.MeatType  = MeatType.Salami;
            this.sandwich.CheeseType = CheeseType.Provolone;
          
        }

        public override void PrepareBread()
        {
            this.sandwich.BreadType = BreadType.Wheat;
            this.sandwich.IsToasted = true;
        }

        public override void AddCondiments()
        {
            this.sandwich.hasMayo = false;
            this.sandwich.HasMustard = false;
        }

        public override void ApplyVegtables()
        {
            sandwich.vegatables.Add("Carrots");
            sandwich.vegatables.Add("Chilli");
            sandwich.vegatables.Add("Lettuce");
        }
    }
}