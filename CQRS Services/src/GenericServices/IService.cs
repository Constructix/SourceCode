using GenericServices.Services.Models;

namespace GenericServices
{
    public interface IService<T, K> where T : IEntity<K>
    {
        IEntity<K> Get(K id);
    }

    public interface IReadService<T, K> where T : IEntity<K>
    {
        IEntity<K> Get(K id);
    }

    public interface IWriteService<T, K> where T : IEntity<K>
    {
        void Write(T itemToAdd);
    }
}