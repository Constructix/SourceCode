using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Shape> shapes = new List<Shape> {new Rectangle {Height = 292, Width = 45}, new Circle {Radius = 23}};
            AreaCalculator areaCalculator    = new AreaCalculator();
            double total = areaCalculator.Area(shapes.ToArray());

            Console.WriteLine($"Total Area: { total}");
        }
    }

    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }


        public override double Area()
        {
            return Width*Height;
        }
    }


    public class Circle : Shape
    {
        public double Radius { get; set; }

        

        public override double Area()
        {
            return Radius*Radius*Math.PI;
        }
    }

    public class AreaCalculator
    {
        public double Area(Shape[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Area();
            }
            return area;
        }
    }
}
