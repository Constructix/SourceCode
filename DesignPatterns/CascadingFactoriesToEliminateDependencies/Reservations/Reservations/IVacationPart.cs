using System;

namespace CascadingFactories
{
    public interface IVacationPart
    {
        void Reserve();
        void Purchase();
        void Cancel();
    }

    class VacationPart : IVacationPart
    {
        public void Reserve()
        {
           
        }

        public void Purchase()
        {
           
        }

        public void Cancel()
        {
           
        }
    }
}