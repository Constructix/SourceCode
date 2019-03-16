namespace ProductCreation
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public decimal UnitPrice { get; }

        public Product()
        {

        }

        public Product(int id, string name, decimal unitPrice)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
        }
    }
}
