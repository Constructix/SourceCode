using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using Shouldly;
using Xunit;
using static EventSourceDemo.Ship;

namespace EventSourceDemo
{
    public class UnitTest1
    {

        EventProcessor eProc = new EventProcessor();
        Cargo newCargo  = new Cargo("Refactor");
        Ship kr = new Ship("King Roy");
        Port sfo = new Port("San Francisco", Country.US);
        Port la = new Port("Los Angeles", Country.US);
        Port yyv = new Port("Vancouve", Country.Canada);
        private static Cargo name;


        public UnitTest1()
        {
        }

       
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void ArrivalSetShipsLocation()
        {
            ArrivalEvent ev = new ArrivalEvent(new DateTime(2005, 11, 1), sfo, kr);
            eProc.Process(ev);
            kr.Port.ShouldBe(sfo);
        }

        [Fact]
        public void LoadCargoEventToKingRoy()
        {
            LoadCargoEvent lce  = new LoadCargoEvent(new DateTime(), kr, newCargo );
            lce.Process();
            kr.Cargo.Count.ShouldBeGreaterThan(0);
        }
    }

    public enum Country
    {
        US,
        Canada
    }

    public abstract class BaseEvent
    {
        protected DateTime Recorded { get; private set; }
        protected DateTime Occurred { get; private set; }
        protected BaseEvent(DateTime ocurred)
        {
            this.Occurred = ocurred;
            Recorded = DateTime.Now;
        }

        public abstract void Process();
    }

    public class EventProcessor
    {
        IList log = new ArrayList();

        public void Process(BaseEvent baseEvent)
        {
            baseEvent.Process();
            log.Add(baseEvent);
        }
    }

    public class DepartureEvent : BaseEvent
    {
        public Port Port { get; private set; }
        public  Ship Ship { get; private set; }

        public DepartureEvent(DateTime time, Port port, Ship ship) : base(time)
        {
            this.Port = port;
            this.Ship = ship;
        }
        public override void Process()
        {
            Ship.HandleDeparture(this);
        }
    }

    public class ArrivalEvent :BaseEvent
    {
        public Port Port { get; private set; }
        public Ship Ship { get; private set; }
        public ArrivalEvent(DateTime time, Port port, Ship ship) : base(time)
        {
            this.Port = port;
            this.Ship = ship;
        }

        public override void Process()
        {
            Ship.HandleArrival(this);
        }
    }

    public class LoadCargoEvent : BaseEvent
    {
        public Ship ship { get; private set; }
        public Cargo Cargo { get; private set; }

        public LoadCargoEvent(DateTime ocurred, Ship ship, Cargo cargo) : base(ocurred)
        {
            this.ship = ship;
            Cargo = cargo;
        }

        public override void Process()
        {
            ship.HandleLoadCargo(this);
        }
    }


    public class UnloadEvent : BaseEvent
    {
        public UnloadEvent(DateTime ocurred, Cargo cargo, Ship ship) : base(ocurred)
        {
            Cargo = cargo;
            Ship = ship;
        }

        public Cargo Cargo { get; private set; }
        public Ship Ship { get; private set; }
        public override void Process()
        {
            Ship.HandleUnloadCargo(this);
           
        }
    }

    public class Ship
    {
        public  IList Cargo { get; private set; }
        public string Name { get; private set; }

        public Ship(string name)
        {
            this.Name = name;
        }
        public Port Port { get; private set; }
        public void HandleDeparture(DepartureEvent departureEvent)
        {
            Port = departureEvent.Port;
        }

        public void HandleArrival(ArrivalEvent arrivalEvent)
        {
            Port = arrivalEvent.Port;
        }

        public void HandleLoadCargo(LoadCargoEvent loadCargoEvent)
        {
            if (Cargo == null)
                Cargo = new List<Cargo>();

            Cargo.Add(loadCargoEvent.Cargo);
        }

        public void HandleUnloadCargo(UnloadEvent unloadCargoEvent)
        {
            Cargo.Remove(unloadCargoEvent.Cargo);
        }
    }

    public class Port
    {
        public string Name { get; private set; }
        public Country Country { get; private set; }

        public Port(string name, Country country)
        {
            this.Name = name;
            this.Country = country;
        }
    }

    public class Cargo
    {
        public string Name { get; private set; }

        public Cargo(string name)
        {
            Name = name;
        }
        public bool HasBeenInCanada = false;
        public void HandleArrival(UnloadEvent arrivalEvent)
        {
            if (arrivalEvent.Ship.Port.Country == Country.Canada)
            {
                HasBeenInCanada = true;
            }
        }
    }

}
