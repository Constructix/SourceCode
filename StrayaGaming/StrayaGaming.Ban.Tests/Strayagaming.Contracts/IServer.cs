using System.Collections;
using System.Collections.Generic;

namespace StrayaGaming.Contracts
{
    public interface IServer
    {
        string Name { get; set; }
        string Address { get; set; }
        string Port { get; set; }

        List<IPlayer> Players { get; set; }
    }
}