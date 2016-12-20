namespace BridgeDesignPattern
{
    public class RefinedBaseAbstraction : BaseAbstraction
    {

        public RefinedBaseAbstraction(IBaseImplementor implementor)
        {
            _Implementor = implementor;
        }

        public override void Operation()
        {
            _Implementor.OperationImp();
        }
    }
}