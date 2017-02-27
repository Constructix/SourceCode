using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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




        }
    }
}
