using System;

namespace ConsoleApp1.Charges
{
    public class Charge
    {
        public decimal Rate { get; private set; }
        public DateTime EffectiveFrom { get; private set; }
        public DateTime? EffectiveTo { get; private set; }
        public bool IsDailyCharge { get; private set; }
        public string Description { get; private set; }

        public Charge(string description, decimal rate, DateTime effectiveFrom, DateTime? effectiveTo, bool isDailyCharge = true)
        {
            this.Description = description;
            this.Rate = rate;
            this.EffectiveFrom = effectiveFrom;
            this.EffectiveTo = effectiveTo;
            this.IsDailyCharge = isDailyCharge;
        }
    }
}