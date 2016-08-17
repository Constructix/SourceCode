

namespace BridgePattern
{
    public abstract class Manuscript
    {

        protected readonly IFormatter formatter;

        public Manuscript(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        public abstract void Print();
    }
}