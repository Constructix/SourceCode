namespace OrderServices.Domain
{
    public class OrderStatus
    {
        public string Value { get; set; }

        public OrderStatus()
        {

        }

        public OrderStatus(string status)
        {
            this.Value = status;
        }

        public static OrderStatus Created => new OrderStatus("Created");
        public static OrderStatus Cancelled => new OrderStatus("Cancelled");
        public static OrderStatus Changed => new OrderStatus("Changed");
        public static OrderStatus Completed => new OrderStatus("Complete");

        public static implicit operator string(OrderStatus status)
        {
            return status.Value;
        }

        public static implicit operator OrderStatus(string value)
        {
            switch (value)
            {
                case "Created":
                    return Created;
                case "Cancelled":
                    return Cancelled;

            }
            return null;                
        }
    }
}
