using Constructix.Core.Common.Data;

namespace Constructix.OnLineServices.Data
{
    public abstract class DataRepositoryBase<T>: DataRepositoryBase<T, ConstructixContext> where T : class, new()
    {
        
    }
}