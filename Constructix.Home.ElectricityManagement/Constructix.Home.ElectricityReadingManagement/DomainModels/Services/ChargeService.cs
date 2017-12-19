using System;
using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Business.DomainModels.Charges;

namespace Constructix.Home.Electricity.Business.DomainModels.Services
{
    public class ChargeService
    {
        private List<SupplyCharge> _charges;
        public ChargeService(List<SupplyCharge> charges)
        {
            _charges = charges;
        }

        public ICharge GetLatestCharge(string supplyCharge)
        {
            return _charges.FirstOrDefault(x => x.Description.Contains(supplyCharge) && !x.EffectiveTo.HasValue);
        }


        public List<SupplyCharge> GetCharge(string supplyCharge, DateTime effectiveFrom, DateTime? effectiveTo)
        {
            return _charges.Where(x =>
                x.Description.Contains(supplyCharge) && 
                x.EffectiveFrom.Date <= effectiveFrom.Date &&
                x.EffectiveTo.GetValueOrDefault().Date >= effectiveTo.GetValueOrDefault().Date).ToList();
        }
    }
}