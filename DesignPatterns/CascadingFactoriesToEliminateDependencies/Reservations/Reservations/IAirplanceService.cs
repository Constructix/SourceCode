using System;

namespace CascadingFactories
{
    public interface IAirplanceService
    {
        IVacationPart SelectFlight(string companyName, string origin, string destination, DateTime travelDate);
    }
}