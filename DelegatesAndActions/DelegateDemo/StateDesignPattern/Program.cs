﻿using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace StateDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Context c = new Context(new ConcreteStateA());

            c.Request();
            c.Request();


        }
    }
}
