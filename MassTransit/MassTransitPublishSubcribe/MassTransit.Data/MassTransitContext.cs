using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit.MessageContract;

namespace MassTransit.Data
{
    public class MassTransitContext : DbContext
    {

        public DbSet<AddressDetails> AddressDetails { get; set; }


        public MassTransitContext() : base("database")

        {
            
        }
    }
}
