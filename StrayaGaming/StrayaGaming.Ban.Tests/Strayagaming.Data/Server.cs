using System.Collections.Generic;
using StrayaGaming.Contracts;

namespace StrayaGaming.Data
{
    public class Server : IServer, IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public virtual List<IPlayer> Players { get; set; }

        public Server()
        {
            Players = new List<IPlayer>();
        }
    }


    public class ServerPlayer : IEntity<int>
    {
        public int Id { get; set; }

        public virtual List<IServer> Servers { get; set; }
        public virtual List<Player> Players { get; set; }

    }
}