using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructix.OnLineServices.Data.Contracts
{
    public class ProductCategory : IProductCategory
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public DateTime? RemovedOn { get; set; }


        public ProductCategory()
        {
            Created = DateTime.Now;
        }
    }
}
