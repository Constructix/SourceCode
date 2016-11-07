using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServiceTest
{
    public class Order
    {
        public DateTime Created { get; set; }

        public int Id { get; set; }
    }


    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
    }


    public class OrderInputData
    {
        public DateTime Created { get; set; }
    }

    public class CustomerInputData
    {
        public string FirstName { get; set; }
    }



   
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        IQueryable<TEntity> Get(Func<TEntity, bool> query);
    }

    public class CustomerRepository : BaseRepository<Customer>
    {
       
    }

    public class OrderRepository : BaseRepository<Order>
    {
        
    }

    public interface IFactory<TObject, TInputData>
    {
        TObject Create(TInputData inputData);
    }

    public abstract class BaseFactory<TObject, TInputData> : IFactory<TObject, TInputData>
    {
        public abstract TObject Create(TInputData inputData);
    }

    public class CustomerFactory : BaseFactory<Customer, CustomerInputData>
    {
        public override Customer Create(CustomerInputData customerInputData)
        {
            return new Customer { FirstName = customerInputData.FirstName };
        }
    }



    public class OrderFactory : IFactory<Order, OrderInputData>
    {
        public Order Create(OrderInputData inputData)
        {
            return new Order {Created = inputData.Created};
        }
    }


}
