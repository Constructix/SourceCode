using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Scotts Pizza", Location = "Maryland", Cuisine = CuisientType.Italian},
                new Restaurant {Id = 2, Name = "Cinnomon Club", Location = "London", Cuisine = CuisientType.Indian},
                new Restaurant {Id = 3, Name = "La Costa", Location = "Maryland", Cuisine = CuisientType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return restaurants.Where(x => string.IsNullOrWhiteSpace(x.Name) || x.Name.StartsWith(name))
                .OrderBy(y => y.Name);
        }
    }
}