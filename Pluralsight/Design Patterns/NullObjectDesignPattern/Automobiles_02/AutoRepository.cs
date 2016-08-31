using System;
using System.Collections.Generic;
using System.Linq;

namespace Automobiles_02
{
    internal class AutoRepository
    {
        private IList<AutomobileBase> _mobiles;
        public AutoRepository()
        {
            _mobiles = new List<AutomobileBase>();

            _mobiles.Add(new Bmw335Xi() );
            _mobiles.Add(new MiniCooper());
        }

        public IEnumerable<AutomobileBase> FindAllByName(string name)
        {
            return _mobiles.Where(x => x.Name.StartsWith(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public AutomobileBase Find(string carName)
        {

            if(_mobiles.Any(x=>x.Name.Contains(carName)))
                return new Bmw335Xi();
            else
            {
                return AutomobileBase.Null;
                
            }
        }
    }
}