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

        /// <summary>
        /// Subtracts the firstReadingValue from the secondreading value.
        /// </summary>
        /// <param name="firstReading"></param>
        /// <param name="secondReading"></param>
        /// <returns></returns>
        public static int Subtract(Reading firstReading, Reading secondReading)
        {
            return secondReading.Value - firstReading.Value;
        }
    }
}