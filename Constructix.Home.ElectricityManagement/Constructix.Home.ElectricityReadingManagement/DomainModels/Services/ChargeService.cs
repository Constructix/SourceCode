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

        public ICharge GetCharge(string supplyCharge)
        {
            return _charges.FirstOrDefault(x => x.Description.Contains(supplyCharge) && !x.EffectiveTo.HasValue);
        }
    }
}