using System.Collections.Generic;

namespace ConsoleApp1
{
    class CarRepository
    {
        public IEnumerable<Car> GetAll()
        {
            IEnumerable<Car> cars = new Car[]
            {
                new Car("Renault", "Megane", new Engine(66, 1598), Seat.FourSeatConfiguration),
                new Car("Ford", "Focus", new Engine(74, 1596), Seat.FourSeatConfiguration),
                new Car("Toyota", "Corlla", new Engine(78, 1587),Seat.FourSeatConfiguration),
                new Car("Mercedes-Benz","SLK250", new Engine(201,1800), Seat.TwoSeatConfiguration) };
            return cars;
        }
    }
}