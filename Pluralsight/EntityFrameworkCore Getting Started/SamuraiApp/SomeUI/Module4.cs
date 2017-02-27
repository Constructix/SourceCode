using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using SamaraiApp.Domain;
using SamuraiApp.Data;

namespace SomeUI
{
    class Module4
    {

        private static SamuraiContext _context = new SamuraiContext();
        private static void QueryAndUpdateSamuraiDisconnected()
        {
            var battle = _context.Battles.FirstOrDefault() ?? new Battle();
            battle.EndDate  = new DateTime(1754,12,31);
            using(var contextNewAppInstance = new SamuraiContext())
            {
                contextNewAppInstance.Battles.Update(battle);
                contextNewAppInstance.SaveChanges();
            }
            //var samurai = _context.Samurais.FirstOrDefault(s => s.Name.Equals("kikuchiyo"));
            //samurai.Name += "San";
            //using (var contextNewAppInstance = new SamuraiContext())
            //{
            //    contextNewAppInstance.Samurais.Update(samurai);
            //    contextNewAppInstance.SaveChanges();
            //}
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }

        private static void MoreQueries()
        {
            var name = "Sampson";
            var samurais = _context.Samurais.Where(x => x.Name.Equals(name)).ToList();

            var find_Samurais = _context.Samurais.Find(2);


        }

        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
                foreach (Samurai samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }

        private static void  InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Julie" };
            var samuraiSammy = new Samurai {Name = "Sampson"};


            using (var context = new SamuraiContext())
            {

                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());

                context.Samurais.AddRange(new List<Samurai> { samurai, samuraiSammy});
                context.SaveChanges();
            }

        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai {Name = "Julie"};

            using (var context = new SamuraiContext())
            {

                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
    }
}