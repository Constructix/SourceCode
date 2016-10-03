using System;
using Newtonsoft.Json.Linq;

namespace CSharpNewFeatures
{
    public class Point
    {
        public  event EventHandler<PointEventArgs> PointEventHandler;

        public int X { get; } = 5;
        public int Y { get; } = 7;

        public Point(int x, int y) { X = x;Y = y;}

        public double Distance => Math.Sqrt(X * X + Y * Y);
        
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