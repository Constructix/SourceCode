using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Domain;

namespace OrderServices.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
       // private IOrderService orderService;
       private IAdaptee<Order> orderAdaptee;

        public OrdersController(IAdaptee<Order> orderAdaptee)
        {
            this.orderAdaptee = orderAdaptee;
        }

        

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return orderAdaptee.GetAll();
        }

        [HttpPost]
        public ActionResult<Order> GetCreatedOrder()
        {
            return orderAdaptee.Create();
        }
    }


    public interface IAdaptee<T> where T : class
    {
        List<T> GetAll();
        Order Create();
    }

    public class OrdersAdapter : IAdaptee<Order>
    {
        private readonly IOrderService _orderService;

        public OrdersAdapter()
        {
            
        }

        public OrdersAdapter(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public List<Order> GetAll()
        {
            return _orderService.GetAll();
        }

        public Order Create()
        {
            return  _orderService.CreateOrder();
        }
    }
     
}