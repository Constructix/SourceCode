namespace ConsoleApp1
{
    public class OrderSubmitStatus
    {
        private OrderSubmitStatus(string value)
        {
            this.Value = value;
        }

        private string Value { get; }
        public static OrderSubmitStatus Ok => new OrderSubmitStatus("OK");
        public static OrderSubmitStatus Error => new OrderSubmitStatus("Error");
        public static OrderSubmitStatus Unknown =>new OrderSubmitStatus("Unknown");
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }

        public static bool operator ==(OrderSubmitStatus status1, OrderSubmitStatus status2)
        {
            return status1.Value.Equals(status2.Value);
        }
        public static bool operator !=(OrderSubmitStatus status1, OrderSubmitStatus status2)
        {
            return !status1.Value.Equals(status2.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderSubmitStatus status)
            {
                return this.Value.Equals(status.Value);
            }
            return false;
        }
    }
}