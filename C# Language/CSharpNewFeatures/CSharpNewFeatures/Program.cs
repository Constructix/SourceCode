using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static System.Math;
namespace CSharpNewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {



            Point p = new Point(10,4);

            Console.WriteLine(p.Distance);
            Console.WriteLine(p);
            Console.WriteLine("To Json object");
            Console.WriteLine(p.ToJson());


            string json = @"{x:10,y:5}";
            JObject j = JObject.Parse(json);


            Point newPoint = Point.FromJson(j);
            newPoint.PointEventHandler += NewPoint_PointEventHandler; ;

            newPoint.HandleRequest();
            Console.WriteLine(newPoint.ToString());

        }

        private static void NewPoint_PointEventHandler(object sender, PointEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public class PointEventArgs : EventArgs
    {
        public Point Point { get; set; }
        public string Message { get; set; }
    }

    

    public class Point
    {
        public  event EventHandler<PointEventArgs> PointEventHandler;

        public int X { get; } = 5;
        public int Y { get; } = 7;

        public Point(int x, int y) { X = x;Y = y;}

        public double Distance => Sqrt(X * X + Y * Y);
        
        public override string ToString() =>$"({X}, {Y})";

        // index Initialisers
        public JObject ToJson() => new JObject() {["x"] = X, ["y"] = Y};

        public void HandleRequest()
        {
            var local = PointEventHandler;
            local?.Invoke(this, new PointEventArgs() { Point = new Point(this.X, this.Y), Message = "Point has handled request from function HandleRequest()"});
        }
        public static Point FromJson(JObject json)
        {
            if (json?["x"]?.Type == JTokenType.Integer &&
                json?["y"]?.Type == JTokenType.Integer)
            {
                return new Point((int) json["x"], (int) json["y"]);
            }
            return null;
        }
    }

}
