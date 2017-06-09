using System;

namespace CascadingFactories
{
    class VactionPartFactory : IVactionPartFactory
    {
        private IHotelService hotelService;
        private IHotelSelector hotelSelector;
        private IAirplanceService airplanceService;

        public VactionPartFactory( IHotelSelector hotelSelector, IHotelService hotelService, IAirplanceService airplanceService)
        {
            this.hotelService = hotelService;
            this.hotelSelector = hotelSelector;
            this.airplanceService = airplanceService;

        }

        public IVacationPart CreateHotelReservation(string town, string hotelName, DateTime arrivalDate, DateTime leavDate)
        {

            Console.WriteLine($"Looking up hotel {hotelName} in {town}");
            HotelInfo hotel = this.hotelSelector.SelectHotel(town, hotelName);
            Console.WriteLine("Waiting for hotel booking service to respond...");
            IVacationPart part = this.hotelService.MakeBooking(hotel, arrivalDate,leavDate);

            return part;
        }

        public IVacationPart CreateFlight(string companyName, string source, string destination, DateTime date)
        {

            Console.WriteLine($"Booking flight {source}  - {destination} on {date.ToString("dd-MMM-yyyy")}");
            IVacationPart part = this.airplanceService.SelectFlight(companyName, source, destination,date);
            return part;
        }

        public IVacationPart CreateDailyTrip(string tripName, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IVacationPart CreateMessage(string salon, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}