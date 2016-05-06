using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Constructix.OnLineServices.Tests
{
    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private ObservableCollection<T> _data;
        private IQueryable _query;

        public FakeDbSet()
        {
            _data = new ObservableCollection<T>();
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        Expression  IQueryable.Expression { get { return _data.AsQueryable().Expression; } }
        public Type ElementType { get { return _query.ElementType; } }
        IQueryProvider IQueryable.Provider { get { return _data.AsQueryable().Provider; } }
        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IList<T> items)
        {
            foreach (T item in items)
            {
                this.Add(item);
            }
        }

        public T Add(T entity)
        {
            _data.Add(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            _data.Remove(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            _data.Add(entity);
            return entity;
        }
        

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local { get; }
    }
}