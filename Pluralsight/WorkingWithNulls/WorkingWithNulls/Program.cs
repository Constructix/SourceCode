﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithNulls
{
    class Program
    {
        static void Main(string[] args)
        {


            PlayerCharacter sarah = new PlayerCharacter(new DiamondSkinDefence()) { Name = "Sarah"};

            PlayerCharacter amrit = new PlayerCharacter(new IronBoneDefence()) { Name="Amrit"};

            PlayerCharacter gentry = new PlayerCharacter(SpecialDefence.Null) { Name = "Gentry"};


            sarah.Hit(10);
            amrit.Hit(10);
            gentry.Hit(10);

            Console.ReadLine();

        }
    }
}
