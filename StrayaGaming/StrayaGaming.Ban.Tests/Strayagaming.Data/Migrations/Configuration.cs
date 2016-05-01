using StrayaGaming.Contracts;
using StrayaGaming.Data;

namespace Strayagaming.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StrayaGaming.Data.StrayaGamingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StrayaGaming.Data.StrayaGamingContext context)
        {
            context.Servers.AddOrUpdate(x => x.Id,
                new Server {Id = 1, Address = "45.121.211.26", Port = "2882", Name = "Invade & Annexe"});
            context.SaveChanges();


            var newPlayer = new Player
            {
                Id = Guid.Parse("42e1fde490cfbf33e1038c30762c45db"),
                Name = "Richard",
                Created = DateTime.Today,
                Status = PlayerStatus.Playing,
                IpAddress = "219.74.244.56"
            };
            context.Players.AddOrUpdate(x => x.Id, newPlayer);
            context.SaveChanges();


            context.Bans.AddOrUpdate(x=>x.Id, new Ban { });
        }
    }
}
