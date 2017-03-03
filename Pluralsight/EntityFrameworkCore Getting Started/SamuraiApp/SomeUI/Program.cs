using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using SamaraiApp.Domain;
using SamuraiApp.Data;

namespace SomeUI
{
    class Program
    {

        private static SamuraiContext _context;

        public Program()
        {
            _context = new SamuraiContext();
            _context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
        }

        static void Main(string[] args)
        {

            _context = new SamuraiContext();
            _context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
            //InsertSamurai();
            //InsertMultipleSamurais();
            // SimpleSamuraiQuery();
            // MoreQueries();
            //RetrieveAndUpdateSamurai();
            //QueryAndUpdateSamuraiDisconnected();
            //InsertNewPkFKGraph();
            EagerLoadWithInclude();
        }

        private static void EagerLoadWithInclude()
        {
            _context = new SamuraiContext();
            var samuraiWithQuotes = _context.Samurais.Include(x => x.Quotes).ToList();
            foreach (var VARIABLE in samuraiWithQuotes)
            {
                
            }
        }
        private static void InsertNewPkFKGraph()
        {
            var samurai = new Samurai
            {
                Name = "Kambei Shimada",
                Quotes = new List<Quote> {new Quote {Text = "I've come to save you"}}

            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
    }
}
