using System;
using System.Collections.Generic;

namespace PluralsightData
{
    public class VendorComparer : Comparer<Vendor>
    {
        public override int Compare(Vendor x, Vendor y)
        {
            return String.Compare(x.CompanyName, y.CompanyName, StringComparison.Ordinal);
        }
    }
}