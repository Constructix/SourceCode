using System.Runtime.Serialization;

namespace WCFFaultHandling.Contracts
{
    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public Product SelectedProduct { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}