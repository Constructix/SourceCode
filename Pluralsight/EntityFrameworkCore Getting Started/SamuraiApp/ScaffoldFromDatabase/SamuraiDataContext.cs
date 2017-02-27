using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


// to Scaffold from a database 
// type:
// scaffold-dbcontext "Server=(localdb)\mssqllocaldb;Database=SamuraiData;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
// generates classes and context class.
namespace ScaffoldFromDatabase
{
    public partial class SamuraiDataContext : DbContext
    {
        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<SamuraiBattle> SamuraiBattle { get; set; }
        public virtual DbSet<Samurai> Samurais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SamuraiData;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasIndex(e => e.SamuraiId)
                    .HasName("IX_Quotes_SamuraiId");

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.SamuraiId);
            });

            modelBuilder.Entity<SamuraiBattle>(entity =>
            {
                entity.HasKey(e => new { e.BattleId, e.SamuraiId })
                    .HasName("PK_SamuraiBattle");

                entity.HasIndex(e => e.SamuraiId)
                    .HasName("IX_SamuraiBattle_SamuraiId");

                entity.HasOne(d => d.Battle)
                    .WithMany(p => p.SamuraiBattle)
                    .HasForeignKey(d => d.BattleId);

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.SamuraiBattle)
                    .HasForeignKey(d => d.SamuraiId);
            });
        }
    }
}