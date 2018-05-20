namespace EntityFrameworkCoreDemo
{
    public interface IEntity<T>
    {
        T Id { get;set;}
    }
}