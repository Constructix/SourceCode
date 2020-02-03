

namespace FTGO.Services.Kitchen
{
    using System;
    using FTGO.Domain;

    public class KitchenService : IFTOService
    {
        public KitchenService()
        {
          
        }
        public Ticket CreateTicket()
        {
            return new Ticket{ Created =  DateTime.Now, Id =  Guid.NewGuid(), LastMOdified =  DateTime.Now};
        }

        /// <summary>
        /// Kitchen accepts the order
        /// </summary>
        /// <param name="order">Order object that client</param>
        public AcceptOrderResponse AcceptOrder(Order order)
        {
            // accept Order
            return new AcceptOrderResponse { Status = AcceptOrderStatus.Accepted};
        }
    }


    public enum AcceptOrderStatus
    {
        Accepted,
        Rejected,
        OnHold
    }
    public class AcceptOrderResponse
    {
        public  AcceptOrderStatus Status { get; set; }
    }
}
