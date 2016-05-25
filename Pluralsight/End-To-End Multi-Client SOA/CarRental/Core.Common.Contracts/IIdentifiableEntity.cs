using System.Security.Cryptography.X509Certificates;

namespace Core.Common.Contracts
{
    public interface IIdentifiableEntity
    {
        int EntityId { get; set; }

    }
}