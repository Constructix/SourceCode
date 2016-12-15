namespace BridgeDesignPattern
{
    public interface IBaseImplementor
    {
        void OperationImp();
    }



    public abstract class BaseLogProvider
    {
        public abstract void WriteLog(string message);
    }



}