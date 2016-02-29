using Core.Common.Contracts;
using Core.Common.Core;

namespace CarRental.Business.Entities
{
    public class Rental : EntityBase, IIdentifiableEntity
    {
        public int EntityId { get; set; }
    }
}