using System.Data.Entity;

namespace StrayaGaming.Data
{
    public class StrayaGamingContext : DbContext
    {
        public DbSet<Server> Servers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Ban> Bans { get; set; }


        public StrayaGamingContext() : base("name=StrayaGaming")
        {
            
        }
    }
}