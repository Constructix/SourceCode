using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    public class Sandwich
    {
        public BreadType BreadType { get; set; }
        public bool IsToasted { get; set; }
        public CheeseType CheeseType { get; set; }
        public MeatType MeatType { get; set; }
        public bool HasMustard { get; set; }
        public  bool hasMayo { get; set; }
        public  List<string> vegatables { get; set; }

        public Sandwich()
        { 
            vegatables = new List<string>();
        }

        public void Display()
        {
            Console.WriteLine($"Sandwich on {BreadType} bread");
            Console.WriteLine(IsToasted ? "Toasted" : string.Empty);
            Console.WriteLine(hasMayo ? "With Mayo" : string.Empty);
            Console.WriteLine(HasMustard ?"With Mustard": string.Empty);
            Console.WriteLine($"Meat: {MeatType}");
            Console.WriteLine($"Veggies: ");
            foreach (string vegatable in vegatables)
            {
                Console.WriteLine($"\t{vegatable}");
            }
        }
    }
}