namespace CascadingFactories
{
    public class HotelSelector : IHotelSelector
    {


        private string destinationTown;
        private string hotelName;
        public HotelInfo SelectHotel(string destinationTown, string hotelName)
        {
            return new HotelInfo();
            this.destinationTown = destinationTown;
            this.hotelName = hotelName;
        }
    }
}