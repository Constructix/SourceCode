using System;

namespace CascadingFactories
{
    public interface IHotelService
    {
        IVacationPart MakeBooking(HotelInfo hotel, DateTime checkin, DateTime checkout);
    }
}