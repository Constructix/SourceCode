﻿using System;

namespace OdeToFood.Core
{
    public class Restaurant
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisientType Cuisine { get; set; }
    }
}
