namespace BuilderPattern
{
    public  class ClubSandwichBuilder: SandwichBuilder
    {
        public override void ApplyMeatAndCheese()
        {
            sandwich.MeatType  = MeatType.Ham;
            sandwich.CheeseType = CheeseType.Swiss;
        }

        public override void PrepareBread()
        {
            sandwich.BreadType = BreadType.Wheat;
            sandwich.IsToasted = false;
        }

        public override void AddCondiments()
        {
            sandwich.HasMustard = true;
            sandwich.hasMayo = true;
        }

        public override void ApplyVegtables()
        {
            sandwich.vegatables.Add("Tomato");
            sandwich.vegatables.Add("Onion");
            sandwich.vegatables.Add("Lettuce");
        }
    }
}