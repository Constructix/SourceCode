using System;

namespace EventDemo
{
    public class OrderBuilder
    {
       
        private DateTime? _created;
        private Guid? _id;

        private OrderStatus status = OrderStatus.Created;
        public OrderBuilder SetId(Guid newId)
        {
            _id = newId;
            return this;
        }
        public OrderBuilder SetCreated()
        {
            _created = DateTime.Now;
            return this;
        }

        public Order Build()
        {
            var order = new Order();
            if (_id.HasValue)
                order.Id = _id.Value;
            if (_created.HasValue)
                order.Created = _created.Value;
            order.Status = OrderStatus.Created;

            return order;

        }
    }
}