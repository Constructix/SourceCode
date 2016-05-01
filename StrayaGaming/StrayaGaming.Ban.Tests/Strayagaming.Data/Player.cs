using System;
using System.Collections.Generic;
using StrayaGaming.Contracts;

namespace StrayaGaming.Data
{
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string IpAddress { get; set; }
        public DateTime? BannedOn { get; set; }
        public PlayerStatus Status { get; set; }
        public virtual   List<IBan> Bans { get; set; }
        public Player()
        {
            Bans = new List<IBan>();
            BannedOn = DateTime.Now;
        }
    }
}