using System;
using System.Dynamic;

namespace CarRental.Client.Entities
{
    public class Car
    {
        int _carId;
        string _description;
        string _color;
        private int _year;
        private decimal _rentalPrice;
        private bool _currentlyRented;

        public int CardId
        {
            get { return _carId;    }
            set { _carId = value;   }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public decimal RentalPrice
        {
            get { return _rentalPrice; }
            set { _rentalPrice = value; }
        }

        public bool CurrentlyRented
        {
            get { return _currentlyRented; }
            set { _currentlyRented = value; }
        }
    }
}