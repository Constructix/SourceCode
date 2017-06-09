using System;

namespace CompositeDesignPattern
{
    public class Painter : IPainter
    {

        private string name;
        private int daysPerHouse;

        public Painter(string name, int daysPerHouse)
        {
            this.daysPerHouse = daysPerHouse;
        }


        public double Paint(double houses)
        {
            double days = this.EstimateDays(houses);

            Console.WriteLine($"{name} painting {houses:0.00} painting {days:0.00}");
            return days;
        }
        

        public double EstimateDays(double houseCount)
        {
            return houseCount * this.daysPerHouse;
        }
    }
}