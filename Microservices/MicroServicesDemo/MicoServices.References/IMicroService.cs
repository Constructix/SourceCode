namespace MicroServicesDemo
{
    public interface IMicroService<T>
    {
        void Start();
        void Stop();
        ServiceStatus Status { get;  set; }

        void Process(T instance);
    }
}