using System.Runtime.Serialization;

namespace WCFCustomBehaviors.Contracts
{
    [DataContract]
    public class SubmitResponse
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Id { get; set; }
    }
}