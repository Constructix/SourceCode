using System;

namespace Constructix.Home.Electricity
{
    public class Reading
    {
        public int Value { get; private set; }
        public DateTime Recorded { get; private set; }
        public Reading(int value, DateTime recorded)
        {
            this.Value = value;
            this.Recorded = recorded;
        }

        public Reading()
        {
            
        }
    }
}