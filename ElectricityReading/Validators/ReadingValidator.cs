using System;
using System.Collections.Generic;

namespace Constructix.Home.Electricity.Validators
{
    public  class ReadingValidator : IValidator<Reading> 
    {
        public  bool IsValid(Reading firstReading, Reading secondReading) => (secondReading.Value >= firstReading.Value);
    }

    public class ReadingComparer : IComparer<Reading>
    {
        public int Compare(Reading x, Reading y)
        {
            return x.Value.CompareTo(y.Value);
        }
    }

   
}