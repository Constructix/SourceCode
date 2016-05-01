using System;
using System.Collections.Generic;

namespace StrayaGaming.Contracts
{
    public interface IPlayer : IEntity<Guid>
    {
        string Name { get; set; }
        DateTime Created { get; set; }
        string IpAddress { get; set; }
        DateTime? BannedOn { get; set; }
        PlayerStatus Status { get; set; }

        List<IBan> Bans { get; set; }
       
    }


   
}