using System.Collections.Generic;
using System.Linq;
using Constructix.OnLineServices.Data.Contracts;

namespace Constructix.OnLineServices.Data.Data
{
    public class ProductCategoryRepository : DataRepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        protected override ProductCategory AddEntity(ConstructixContext entityContext, ProductCategory entity)
        {
            return entityContext.ProductCategorySet.Add(entity);
        }

        protected override ProductCategory UpdateEntity(ConstructixContext entityContext, ProductCategory entity)
        {
            return (from e in entityContext.ProductCategorySet
                where e.Id == entity.Id
                select e).FirstOrDefault();



        }

        protected override IEnumerable<ProductCategory> GetEntities(ConstructixContext entityContext)
        {
            return entityContext.ProductCategorySet.AsEnumerable();
        }

        protected override ProductCategory GetEntity(ConstructixContext entityContext, int id)
        {
            var query = entityContext.ProductCategorySet.FirstOrDefault(x => x.Id == id);
            return query;
        }
    }
}