﻿using System;
using System.Runtime.CompilerServices;

namespace Common
{
    [Serializable]
    public class PurchaseOrder
    {
        public decimal AmountToPay;
        public string PoNumber;
        public string CompanyName;
        public int PaymentDayTerms;
    }
}