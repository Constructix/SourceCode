using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData: IRestaurantData
    {
        private List<Restaurant> _restaurants = new List<Restaurant>();


        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant
                    {Id = 1, Name = "Scotts Pizza", Location = "Maryland", Cuisine = CuisientType.Italian},
                new Restaurant {Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisientType.None},
                new Restaurant {Id = 3, Name = "La Costa", Location = "Madrid", Cuisine = CuisientType.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(x=>x.Name);
        }
    }
}