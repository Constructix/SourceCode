using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace CascadingFactories
{
    class Program
    {

        static IUnityContainer InitialiseContainer()
        {
            //
            // using ContainerControlledLifetimeManger => means singleton Only one instance to be created.

            return new UnityContainer().RegisterType<Application, Application>()
                .RegisterType<IVactionPartFactory, VactionPartFactory>(new ContainerControlledLifetimeManager())
                .RegisterType<IHotelSelector, HotelSelector>(new ContainerControlledLifetimeManager())
                .RegisterType<IHotelService, HotelService>(new ContainerControlledLifetimeManager())
                .RegisterType<IAirplanceService, AirplanceService>(new ContainerControlledLifetimeManager());
        }


        static void Main(string[] args)
        {

            InitialiseContainer()
                .Resolve<Application>()
                .Run();
        }
    }


    public class Application
    {

        private IVactionPartFactory partFactory;

        public Application(IVactionPartFactory partFactory)
        {
            this.partFactory = partFactory;
        }
        public void Run()
        {
            VacationSpecificationBuilder builder = new VacationSpecificationBuilder(partFactory, new DateTime(2017,10,1),14, "Crowded City", "Seatown");

            builder.SelectHotel("Small One");
            builder.SelectAirplane("Big Plane");

            VacationSpecification spec = builder.BuildVaction();


        }
    }
}
