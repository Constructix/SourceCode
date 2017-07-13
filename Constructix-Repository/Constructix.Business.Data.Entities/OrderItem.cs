using System;

namespace Constructix.Business.Data.Entities
{
    public class OrderItem : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
      
        public virtual Order Order { get; set; }

        public OrderItem()
        {
            
            Order = new Order();
            Created = DateTime.Now;
        }
    }
}