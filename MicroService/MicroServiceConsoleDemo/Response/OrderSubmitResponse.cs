using System;

namespace ConsoleApp1
{
    public class OrderSubmitResponse : ISubmitResponse<Order>
    {
        public string Message { get; set; }
        public OrderSubmitStatus Status {get; set; }
        public DateTime Created { get; set; }
        public Order Document { get; set; }

        public OrderSubmitResponse()
        {
            Created = DateTime.Now;
        }

        public OrderSubmitResponse(string message, OrderSubmitStatus status) :this()
        {
            this.Message = message;
            this.Status = status;
        }
    }
}