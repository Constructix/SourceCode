using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        private readonly IConfiguration Config;
        private readonly IRestaurantData _restaurantData;


        public IEnumerable<Restaurant> Restaurants { get; set; }
        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.Config = config;
            _restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = Config["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(string.Empty);
        }
    }
}