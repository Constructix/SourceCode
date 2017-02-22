using Microsoft.EntityFrameworkCore;
using SamaraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // point to SqlServer.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SamuraiData;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(x => new {x.BattleId, x.SamuraiId});

            //modelBuilder.Entity<Samurai>().Property(x => x.SecretIdentity).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}

// For migrations to work will need to install the following:
//install-package Microsoft.EntityFrameworkCore.Tools 
// this enabled migrations.


// use following command to script the database
// script-migration
// Generates the sql script file that can be used by the DBAs to create the database.
