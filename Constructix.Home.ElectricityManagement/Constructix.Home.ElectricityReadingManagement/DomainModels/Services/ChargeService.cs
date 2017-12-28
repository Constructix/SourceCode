using System;
using System.Collections.Generic;
using System.Linq;
using Constructix.Home.Electricity.Business.DomainModels.Charges;

namespace Constructix.Home.Electricity.Business.DomainModels.Services
{


    public interface IChargeService
    {
        ICharge GetLatestChange(string chargeName);
        List<SupplyCharge> GetCharge(string chargeName, DateTime effectiveFrom, DateTime? effectiveTo);
    }
    public class ChargeService : IChargeService
    {
        private List<SupplyCharge> _charges;
        public ChargeService(List<SupplyCharge> charges)
        {
            _charges = charges;
        }
        public ICharge GetLatestChange(string chargeName)
        {
            return _charges.FirstOrDefault(x => x.Description.Contains(chargeName) && !x.EffectiveTo.HasValue);
        }

        public List<SupplyCharge> GetCharge(string chargeName, DateTime effectiveFrom, DateTime? effectiveTo)
        {
            return _charges.Where(x =>
                x.Description.Contains(chargeName) && 
                x.EffectiveFrom.Date <= effectiveFrom.Date &&
                x.EffectiveTo.GetValueOrDefault().Date >= effectiveTo.GetValueOrDefault().Date).ToList();
        }
    }
}