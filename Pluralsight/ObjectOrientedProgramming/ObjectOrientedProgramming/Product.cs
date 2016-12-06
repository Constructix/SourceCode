using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace ObjectOrientedProgramming
{
    public interface ILoggable
    {
        string Log();
    }

    public class Customer : ILoggable
    {
        [Key]
        public int Id { get; set; }
        public int CustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Log()
        {
            return $"{Id} : {FirstName} {LastName} Email: {Email}";
        }
    }

    public class Product: ILoggable
    {
        [Key]
        public int ProductId { get; set; }

        public decimal? CurrentPrice { get; set; }
        public string  ProductDescription { get; set; }

        private string _productName;

        public string ProductName
        {
            get { return _productName.InsertSpaceWithCapitalSeparator(); }
            set { _productName = value; }
        }



        public Product()
        {
            
        }

        public Product(int productId)
        {
            this.ProductId = productId;
        }

        public string Log()
        {
            return $"{ProductId} : {ProductName} Detail: {ProductDescription}";
        }
       
    }
}