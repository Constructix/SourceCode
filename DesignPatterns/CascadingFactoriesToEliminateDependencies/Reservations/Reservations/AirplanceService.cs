using System;

namespace CascadingFactories
{
    class AirplanceService : IAirplanceService
    {
        public IVacationPart SelectFlight(string companyName, string origin, string destination, DateTime travelDate)
        {
            return new VacationPart();
        }
    }
}