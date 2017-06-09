using System;

namespace CascadingFactories
{
    internal class HotelService : IHotelService
    {
        public IVacationPart MakeBooking(HotelInfo hotel, DateTime checkin, DateTime checkout)
        {

            // go and simulate making a booking at the hotel.
            var hotelbooking = new VacationPart();
            hotelbooking.Reserve();
            return hotelbooking;
        }
    }
}