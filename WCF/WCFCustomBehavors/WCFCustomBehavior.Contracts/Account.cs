using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WCFCustomBehaviors.Contracts
{
    public class Account
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}