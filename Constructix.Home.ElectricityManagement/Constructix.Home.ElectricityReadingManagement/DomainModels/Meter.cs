using Constructix.Home.Electricity.Business.DomainModels.Readings;

namespace Constructix.Home.Electricity.Business.DomainModels
{
    public class Meter
    {
        public Reading PreviousReading { get; }
        public Reading LatestReading { get; }

        public string MeterNum { get; }


        public Meter(string meterNum, Reading previouReading, Reading latestReading)
        {
            this.MeterNum = meterNum;
            this.PreviousReading = previouReading;
            this.LatestReading = latestReading;
        }
    }
}