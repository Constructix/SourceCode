using System.Collections.Generic;
using Constructix.Core.Common.Data;
using Constructix.OnLineServices.Data.Contracts;

namespace Constructix.OnLineServices.Data.Data
{
    public class ProductCategoryRepository : DataRepositoryBase<ProductCategory>
    {
        protected override ProductCategory AddEntity(ConstructixContext entityContext, ProductCategory entity)
        {
            throw new System.NotImplementedException();
        }

        protected override ProductCategory UpdateEntity(ConstructixContext entityContext, ProductCategory entity)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<ProductCategory> GetEntities(ConstructixContext entityContext)
        {
            throw new System.NotImplementedException();
        }

        protected override ProductCategory GetEntity(ConstructixContext entityContext, int id)
        {
            throw new System.NotImplementedException();
        }
    }

    public abstract class DataRepositoryBase<T>: DataRepositoryBase<T, ConstructixContext> where T : class, new()
    {
        
    }
}