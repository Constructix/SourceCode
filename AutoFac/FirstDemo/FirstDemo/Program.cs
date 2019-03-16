using System;
using System.IO;
using Autofac;
using Autofac.Core;
using FirstDemo.Implementors;
using FirstDemo.Interfaces;

namespace FirstDemo
{
    class Program
    {

        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {


            var builder = new ContainerBuilder();

            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();

            builder.RegisterType<MyComponent>()
                .UsingConstructor(typeof(ConsoleLogger),typeof(TodayWriter));



            Container = builder.Build();
            // The WriteDate method is where we'll make use
            // of our dependency injection. We'll define that
            // in a bit.
            WriteDate();

        }

        private static void WriteDate()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }
    }
    // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Logging Component
    public interface ILogger
    {
        void Write(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger: ILogger
    {
        public void Write(string message)
        {
            File.AppendAllText(@"loggingDemo.txt", message);
        }
    }

    public interface IComponent
    {
        void WriteMessage(string message);
    }

    public class MyComponent
    {
        public ILogger Logger { get; }
        public IOutput Output { get; }

        public MyComponent()
        {
            
        }

        public MyComponent(ILogger logger, IOutput output)
        {
            Logger = logger;
            Output = output;
        }

        public void WriteMessage(string message)
        {
            Logger.Write(message);
            Output.Write(message);
        }
    }


    public class TodayWriter : IDateWriter
    {
        private IOutput _output;
        public TodayWriter(IOutput output)
        {
            this._output = output;
        }

        public void WriteDate()
        {
            this._output.Write(DateTime.Today.ToShortDateString());
        }
    }

}
