using System.Dynamic;

namespace Core.Common.Contracts
{
    public interface IAccountOwnedEntity
    {
        int OwnerAccountId { get; set; }
    }
}