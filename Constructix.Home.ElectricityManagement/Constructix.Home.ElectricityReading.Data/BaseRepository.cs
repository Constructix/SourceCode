using System;
using System.Collections.Generic;
using System.Linq;

namespace Constructix.Home.ElectricityReading.Data
{
    public abstract class BaseRepository<T> : IRepository<T>
    {

        private IList<T> _items;

        public BaseRepository()
        {
            _items = new List<T>();
        }

        public BaseRepository(IList<T> items)
        {
            this._items = items;
        }
        public void Add(T newItem)
        {
            _items.Add(newItem);
        }

        public void Remove(T removeItem)
        {
            if(_items.Contains(removeItem))
                _items.Remove(removeItem);
        }
        public IEnumerable<T> Get(Func< T, bool> expression)
        {
            return _items.Where(expression).AsEnumerable();
        }

        public IList<T> GetAll()
        {
            return _items;
        }
    }
}