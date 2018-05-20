using System.Collections.Generic;

namespace EntityFrameworkCoreDemo
{
    public class Category : IEntity<int>
    {
        private int _id;
        public int Id { get; set; }
        public string Name { get;set;}

        protected List<Supplier> Suppliers { get;set;}
        
    }
}