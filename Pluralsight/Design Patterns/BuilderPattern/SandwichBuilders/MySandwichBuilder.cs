namespace BuilderPattern
{
    public class MySandwichBuilder : SandwichBuilder
    {
       
       
        public override void AddCondiments()
        {
            sandwich.HasMustard = true;
            sandwich.hasMayo = true;
        }

        public override void ApplyVegtables()
        {
            sandwich.vegatables.Add("Tomato");
            sandwich.vegatables.Add("Onion");
        }

        public override void ApplyMeatAndCheese()
        {
            sandwich.MeatType = MeatType.Chicken;
            sandwich.CheeseType = CheeseType.Cheddar;
        }

        public override void PrepareBread()
        {
            sandwich.BreadType = BreadType.Wheat;
            sandwich.IsToasted = true;
        }
    }

  
}