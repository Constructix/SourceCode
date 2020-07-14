namespace ScopedDemo.Models
{
    public class Mobile
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string  Model { get; set; }
        public string  Price { get; set; }

        public Mobile()
        {
            
        }

        public Mobile(int id, string name, string model, string price)
        {
            Id = id;
            Name = name;
            Model = model;
            Price = price;
        }
    }
}