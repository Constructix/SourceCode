using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Repositories
{
    public  class GenericRepository<TContext, TEntity, TKey> where TContext: DbContext 
        where TEntity : class 
                                                            
    {
        protected DbContext Context { get; set; }

        protected DbSet<TEntity> Entity {get; set; }

        public GenericRepository() { }

        public GenericRepository(TContext context)
        {
            this.Context = context;
            Entity = context.Set<TEntity>();

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity Get(TKey key)
        {
            return Context.Set<TEntity>().Find(key);
        }

        public void Add(TEntity newEntity)
        {
            Context.Set<TEntity>().Add(newEntity);
          
        }

        public void AddRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}