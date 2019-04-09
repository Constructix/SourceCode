using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private IRestaurantData _restaurantData;
        

        public string Message { get; set; }
        public void OnGet()
        {
            Message = config["Message"]; //"Hello World!";
        }

        private readonly IConfiguration config;
        public ListModel(IConfiguration configuration)
        {
            config = configuration;
        }
        public ListModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
    }
}