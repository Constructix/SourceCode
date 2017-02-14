using Xunit;

namespace Project1
{
    public class ProductTests
    {
        [Fact]
        public void ProductInstanceNoExceptionExpected()
        {
            IProduct product = new Product();
            Assert.NotNull(product);
        }

        [Fact]
        public void ProductIdIsString()
        {
            IProduct product = new Product() { Id = "12345"};
            Assert.NotNull(product.Id);
        }

        

        
        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        public void QuantityValid(int quantity)
        {
            var productValidator = new ProductValidator();

            var product = new Product() {Quantity = quantity};

            ProductValidator validator  = new ProductValidator();
            var result =  validator.Validate(product);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(-1)]
        public void QuantityNotValidIsLessThanZero(int quantity)
        {
            var productValidator = new ProductValidator();

            var product = new Product() { Quantity = quantity };

            ProductValidator validator = new ProductValidator();
            var result = validator.Validate(product);
            Assert.False(result.IsValid);
        }



    }
}