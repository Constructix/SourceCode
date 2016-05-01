using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StrayaGaming.Contracts;

namespace StrayaGaming.Data
{
    public class Ban : IBan, IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime DateTimeOfBan { get; set; }
        public int Duration { get; set; }
        public DurationType DurationType { get; set; }
        public string Evidence { get; set; }
        public string Notes { get; set; }
        public DateTime? ExpiryDueDate { get; set; }
        public int PlayerId { get; set; }
        public IPlayer Player { get; set; }

        public virtual List<IBan> Bans { get; set; }

    }
}