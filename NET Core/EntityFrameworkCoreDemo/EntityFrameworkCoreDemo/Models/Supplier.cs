using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreDemo
{
    public class Supplier : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WebAddress { get; set; }
        public string Email { get; set; }

        public int CategoryId { get;set;}

        protected List<Category> Categories { get;set;}

       
    }
}