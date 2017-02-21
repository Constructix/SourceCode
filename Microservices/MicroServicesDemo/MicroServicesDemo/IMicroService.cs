﻿using System;

namespace MicroServicesDemo
{
    public interface IMicroService<T>
    {



        void Start();
        void Stop();
        ServiceStatus Status { get;  set; }

        void Process(T instance);
    }

    public abstract class BaseMicroService<T> : IMicroService<T>
    {

        protected bool processService { get; set; }

        public ServiceStatus Status { get;  set; }

        public virtual void Start()
        {
            Status = ServiceStatus.Started;
            Console.WriteLine("Service has started.");
        }

        public virtual  void Stop()
        {
           Status = ServiceStatus.Stopped;
            
        }

       

        public virtual void Process(T instance)
        {
            throw new System.NotImplementedException();
        }

       
    }
}