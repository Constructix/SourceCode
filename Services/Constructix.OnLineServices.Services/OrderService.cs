using System;
using System.Collections.Generic;
using Constructix.OnlineServices.Data;
using Constructix.OnLineServices.Domain;

namespace Constructix.OnLineServices.Services
{
    public class OrderService : IService<Order>
    {

        private readonly IRepository<Order> _ordersRepository;

        public OrderService(IRepository<Order> ordersRepository)
        {
            this._ordersRepository = ordersRepository;

            RepositoryHelper.CreateTestOrder(ordersRepository);
        }

        public Order Get(Guid Id) =>  _ordersRepository.Get(Id);


        public bool Add(Order newOrder)
        {

            _ordersRepository.Add(newOrder);
            return true;
        }


        public void Delete(Order orderToBeDeleted)=>_ordersRepository.Delete(orderToBeDeleted);
        

        public List<Order> GetAll() => _ordersRepository.GetAll();

    }
}
