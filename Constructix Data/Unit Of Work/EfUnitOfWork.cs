using System.Data.Entity;
using Constructix.Data.Repositories;
using Constructix.OnLineServices.Contracts;

namespace Constructix.Data.UnitOfWork
{
    public class EfUnitOfWork : DbContext, IUnitOfWork
    {

        private GenericRepository<Order> _orderRepository;
        

        public IDbSet<Order> Orders { get; set; }
     
        public EfUnitOfWork() : base("name=RepositoryDemo")
        {
            _orderRepository = new GenericRepository<Order>(Orders);
        }

        public IGenericRepository<Order> OrderRepository { get { return _orderRepository; } }
        
        public void Commit()
        {
            base.SaveChanges();
        }
    }
}