using System.Collections.Generic;
using System.Threading.Tasks;

namespace CascadingFactories
{
    public class VacationSpecification
    {
        private IList<IVacationPart> parts;
        public VacationSpecification(IList<IVacationPart> parts)
        {
            this.parts = parts;
        }
    }
}