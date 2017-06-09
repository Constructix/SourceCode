using System;

namespace CascadingFactories
{
    public interface IVactionPartFactory
    {
        IVacationPart CreateHotelReservation(string town, string hotelName, DateTime arrivalDate, DateTime leavDate);
        IVacationPart CreateFlight(string companyName, string source, string destination, DateTime date);
        IVacationPart CreateDailyTrip(string tripName, DateTime date);
        IVacationPart CreateMessage(string salon, DateTime date);
    }
}