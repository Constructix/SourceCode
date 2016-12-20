namespace BridgeDesignPattern
{
    public  abstract class BaseAbstraction
    {

        public BaseAbstraction()
        {
            
        }

        public BaseAbstraction(IBaseImplementor implementor)
        {
            _Implementor = implementor;
        }

        protected IBaseImplementor _Implementor;
        public abstract void Operation();
    }
}