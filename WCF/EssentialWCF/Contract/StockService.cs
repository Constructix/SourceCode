﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class StockService : IStockService
    {
        public double GetPrice(string ticker)
        {
            return 94.85;
        }
    }
}
