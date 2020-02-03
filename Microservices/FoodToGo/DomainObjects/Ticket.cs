using System;

namespace FTGO.Domain
{
    public class Ticket
    {
        public DateTime Created { get; set; }
        public Guid Id { get; set; }
        public DateTime LastMOdified { get; set; }
    }
}