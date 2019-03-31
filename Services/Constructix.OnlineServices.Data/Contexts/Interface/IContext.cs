namespace Constructix.OnlineServices.Data.Contexts
{
    public interface IContext<T>
    {
        T Value { get; set; }

    }
}