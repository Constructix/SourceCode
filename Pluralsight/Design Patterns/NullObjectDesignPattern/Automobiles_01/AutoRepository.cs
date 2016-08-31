using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Automobiles_01
{
    internal class AutoRepository
    {
        private IList<AutoMobile> _mobiles;
        public AutoRepository()
        {
            _mobiles = new List<AutoMobile>();

            _mobiles.Add(new AutoMobile() { Name ="Ford"});
            _mobiles.Add(new AutoMobile() { Name = "Mazda" });
            _mobiles.Add(new AutoMobile() { Name = "Mitsubishi" });
        }

        public IEnumerable<AutoMobile> FindAllByName(string name)
        {
            return _mobiles.Where(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}