using System;
using Core.Common.Core;

namespace CarRental.Client.Entities
{
    public class Rental : ObjectBase
    {
        int _rentalId;
        int _accountId;
        DateTime _dateRented;
        DateTime _dueDate;
        DateTime? _dateReturned;

        public Rental(DateTime? dateReturned)
        {
            _dateReturned = dateReturned;
        }


        public int RentalId
        {
            get { return _rentalId; }
            set
            {
                if (_rentalId != value)
                {
                    _rentalId = value;
                    OnPropertyChanged(()=>RentalId);
                }
            }
        }

        public int AccountId
        {
            get { return _accountId; }
            set
            {
                if (_accountId != value)
                {
                    _accountId = value;
                    OnPropertyChanged(()=>AccountId);
                }
            }
        }

        public DateTime DateRented
        {
            get { return _dateRented; }
            set
            {
                if (_dateRented != value)
                {
                    _dateRented = value;
                    OnPropertyChanged(()=>DateRented);
                }
                
            }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                if (_dueDate != value)
                {
                    _dueDate = value;
                    OnPropertyChanged(()=>DueDate);
                }
            }
        }
    }
}