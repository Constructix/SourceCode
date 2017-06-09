using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            IPaintingScheduler scheduler = new PaintingScheduler();

            IPainter localPaintingCo = new PaintingCompany( new IPainter[] {new Painter("Andy", 7), new Painter("Bill",5)}, scheduler);

            IPainter bestPaintersCo  = new PaintingCompany( new IPainter[]  {new Painter("Joe", 4),new Painter("Jill", 5),new Painter("Buster", 3), localPaintingCo}, scheduler);



            LandOwner owner = new LandOwner(14, bestPaintersCo);
               

            owner.MaintainHouses();


        }
    }
}
