using System;
using System.Collections.Generic;

namespace CQRS_FirstDemo.Commands
{
    public class RateProduct : ICommand
    {
        public Guid Id { get; }

        public int ProductId { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }

        public RateProduct()
        {
            
        }
        public RateProduct(Guid id, int productId, int rating, int userId)
        {
            Id = id;
            ProductId = productId;
            Rating = rating;
            UserId = userId;
        }
    }

    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }


    public class ProductCommandHandler : ICommandHandler<RateProduct>
    {

        private ProductRepository _repository = null;

        public ProductCommandHandler(ProductRepository repository)
        {
            _repository = repository;
        }
        
        public void Handle(RateProduct command)
        {
            var product = _repository.Find(command.ProductId);
            if (product != null)
            {
                _repository.Save(product);
            }
        }
    }

    public class ProductRepository
    {
        
        private List<Product> rateProducts = new List<Product>();
        
        public Product  Find(int commandProductId)
        {
             return rateProducts.Find(x => x.Id == commandProductId);
        }

        public void Save(RateProduct product)
        {
            
            // saving to the database.
            //throw new NotImplementedException();
        }
    }

    internal class  Product
    {
        public int Id { get; set; }

        public Product(int id)
        {
            Id = id;
        }
    }
}