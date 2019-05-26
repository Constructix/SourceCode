namespace MoqDemo_001
{
    public class OrderStatus
    {
        public string Value { get; set; }

        public OrderStatus()
        {
            
        }

        public OrderStatus(string value)
        {
            Value = value;
        }

        public static OrderStatus OK => new OrderStatus("OK");


        public static implicit operator string(OrderStatus status)
        {
            return status.Value;
        }
    }
}