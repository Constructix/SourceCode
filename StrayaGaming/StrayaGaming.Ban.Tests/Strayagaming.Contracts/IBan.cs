using System;
using System.Collections;
using System.Collections.Generic;

namespace StrayaGaming.Contracts
{
    public interface IBan
    {
        string Reason { get; set; }
        DateTime DateTimeOfBan { get; set; }
        int Duration { get; set; }
        DurationType DurationType { get; set; }
        string Evidence { get; set; }
        string Notes { get; set; }
        DateTime? ExpiryDueDate { get; set; }

        int PlayerId { get; set; }
        IPlayer Player { get; set; }
    }
}