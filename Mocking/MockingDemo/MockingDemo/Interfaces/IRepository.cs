namespace MockingDemo
{
    public interface IRepository<T> where T : new()
    {
        void Add(T entityToAdd);
        void Remove(T entityToRemove);
    }
}