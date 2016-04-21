using System.Runtime.Serialization;

namespace WCFCustomBehaviors.Contracts
{
    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public Product Product { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}