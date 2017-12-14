using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors;
using Xunit;

namespace Constructix.Home.ElectricityReadingManagement
{
    public interface IRepository<T>
    {

         void Add(T newItem);
         void Remove(T removeItem);

         IEnumerable<T> Get(Func<T, bool> expression);

        IList<T> GetAll();

    }

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

    public class TariffChargesRepository : BaseRepository<BaseTariff>
    {
        
    }


    public class TariffRepositoryTests
    {
        [Fact]
        public void TariffRepositoryInstanceCreated()
        {
            BaseRepository<BaseTariff> tariffChargesRepository = new TariffChargesRepository();

            var newTariffCharge = new ElectricityTariff(0.26m, DateTime.Parse("01/07/2017"), null);

            tariffChargesRepository.Add(newTariffCharge);
            Assert.True(tariffChargesRepository.GetAll().Any());

            


        }
    }
}