namespace MockingDemo
{
    public abstract class BaseRepository<T> : IRepository<T> where T : new()
    {
        protected ConstructixServicesContext _context;

        public BaseRepository(ConstructixServicesContext constructixServicesContext)
        {
            _context = constructixServicesContext;
        }

        public abstract void Add(T entityToAdd);

        public abstract void Remove(T entityToRemove);
    }
}