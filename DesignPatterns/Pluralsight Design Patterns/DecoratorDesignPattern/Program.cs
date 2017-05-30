using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            IPizza pizza  = new LargePizza();

            pizza = new Cheeze(pizza );
            pizza = new Ham(pizza);
            pizza = new Peppers(pizza);
            Console.WriteLine(pizza.GetDescription());
            Console.WriteLine($"Pizza Cost: {pizza.CalculateCost():C}");

        }
    }


    public interface IPizza
    {
        string Description { get; set; }
        decimal CalculateCost();
        string GetDescription();
    }

    public class LargePizza : IPizza
    {

        public LargePizza()
        {
            Description = "Large Pizza";
        }

        public string Description { get; set; }
        public decimal CalculateCost()
        {
            return 9.00m;
        }

        public string GetDescription()
        {
            return Description;
        }
    }

    public class MediumPizza:IPizza
    {
        public MediumPizza()
        {
            this.Description = "Medium Pizza";
        }

        public string Description { get; set; }


        public decimal CalculateCost()
        {
            return 6.00m;
        }

        public string GetDescription()
        {
            return this.Description;
        }
    }

    public class SmallPizza : IPizza
    {
        public string Description { get; set; }
        public decimal CalculateCost()
        {
            return 3.00m;
        }

        public string GetDescription()
        {
            return "Small Pizza";
        }
    }


    public class PizzaDecorator : IPizza
    {


        public PizzaDecorator()
        {


        }

        public PizzaDecorator(IPizza pizza)
        {
            this.Pizza = pizza;
        }

        protected IPizza Pizza { get; set; }
        public string Description { get; set; }

        public virtual decimal CalculateCost()
        {
            return Pizza.CalculateCost();
        }

        public virtual string GetDescription()
        {
            return Pizza.GetDescription();
        }
    }

    public class Cheeze : PizzaDecorator
    {

        

        public Cheeze(IPizza pizza) : base(pizza)
        {
            Description = "Cheese";
        }

        public override decimal CalculateCost()
        {
            return Pizza.CalculateCost() + 1.25m;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, {Description}";
        }
    }

    public class Ham : PizzaDecorator
        {

            public Ham(IPizza pizza) : base(pizza)
            {
                Description = "Ham";
            }

            public override decimal CalculateCost()
            {
                return Pizza.CalculateCost() + 1.00m;
            }

            public override string GetDescription()
            {
                return $"{base.GetDescription()}, {Description}";
            }
        }

        public class Peppers : PizzaDecorator
        {

            public Peppers(IPizza pizza) : base(pizza)
            {

                Description = "Peppers";
            }

            public override decimal CalculateCost()
            {
            return Pizza.CalculateCost() + 2.00m;
        }

            public override string GetDescription()
            {
                return $"{base.GetDescription()}, {Description}";
            }
        }
    }

