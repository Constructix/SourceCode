using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Constructix.OnLineServices.Data.Contracts.Tests
{
    [TestFixture]
    public class ConstructixContextTests
    {
        [Test]
        public void DatabaseCreated()
        {
            ConstructixContext context = new ConstructixContext();
            ProductCategory category = new ProductCategory {Name = "Timber Decking"};
            context.ProductCategorySet.Add(category);
            context.SaveChanges();
        }

    }
}