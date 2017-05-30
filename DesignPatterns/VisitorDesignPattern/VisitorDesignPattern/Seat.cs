using System.Collections.Generic;

namespace ConsoleApp1
{
    class Seat
    {
        private string name;
        private int capacity;

        public Seat(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
        }

        public static IEnumerable<Seat> FourSeatConfiguration
        {
            get { return new Seat[] {new Seat("Driver", 1),
                new Seat("Passenger",1),
                new Seat("Rear bench",2) }; }
        }

        public static IEnumerable<Seat> TwoSeatConfiguration
        {
            get { return new Seat[] { new Seat("Driver", 1), new Seat("Passenger", 1)}; }
        }

        public void Accept(ICarPartVisitor visitor)
        {
            visitor.VisitSeat(this.name,this.capacity);
        }

    }
}