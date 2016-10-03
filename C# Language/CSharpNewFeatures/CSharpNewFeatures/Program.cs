using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
}
