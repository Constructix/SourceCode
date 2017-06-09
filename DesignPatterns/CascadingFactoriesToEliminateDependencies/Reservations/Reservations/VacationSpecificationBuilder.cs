using System;
using System.Collections;
using System.Collections.Generic;

namespace CascadingFactories
{
    public class VacationSpecificationBuilder
    {
        private IVactionPartFactory partFactory;
        private IList<IVacationPart> parts = new List<IVacationPart>();

        private DateTime arrivalDate;
        private int totalNights;

        private string livingTown;
        private string destinationTown;

        public VacationSpecificationBuilder(IVactionPartFactory partFactory,
                                            DateTime arrivalDate, 
                                            int totalNights, 
                                            string livingTown, 
                                            string destinationTown)
        {
            this.partFactory = partFactory;
           
            this.arrivalDate = arrivalDate;
            this.totalNights = totalNights;

            this.livingTown = livingTown;
            this.destinationTown = destinationTown;
        }
        public void SelectHotel(string hotelName)
        {
            this.parts.Add( partFactory.CreateHotelReservation(destinationTown, hotelName, arrivalDate,arrivalDate.AddDays(this.totalNights)));
        }
        public void SelectAirplane(string companyName)
        {

            Console.WriteLine("Waiting on air ticketing service to respond...");
            this.parts.Add(CreateDestinationFlight(companyName));
            this.parts.Add(CreateOriginFlight(companyName));
        }

        private IVacationPart CreateOriginFlight(string companyName)
        {
            return partFactory.CreateFlight(companyName, destinationTown, livingTown,arrivalDate.AddDays(this.totalNights));
        }

        private IVacationPart CreateDestinationFlight(string companyName)
        {
            return partFactory.CreateFlight(companyName, livingTown, destinationTown, arrivalDate);
        }

        public VacationSpecification BuildVaction()
        {
            foreach (IVacationPart part in this.parts)
            {
                part.Purchase();
            }
            return new VacationSpecification(this.parts);
        }
    }
}