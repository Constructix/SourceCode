using System.Collections.Generic;
using System.Linq;
using GenericServices.Services.Models;

namespace GenericServices
{
    public class GenericService<T, K> : IService<T, K> where T : IEntity<K>
    {
        private List<IEntity<K>> items { get;set; }

        public GenericService()
        {
            items = new List<IEntity<K>>();
        }

        public GenericService(List<IEntity<K>> itemsToAdd)
        {
            items = itemsToAdd;
        }
        public IEntity<K> Get(K id)
        {
            return items.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}