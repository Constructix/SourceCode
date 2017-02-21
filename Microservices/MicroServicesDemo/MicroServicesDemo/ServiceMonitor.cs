using System.Collections.Generic;

namespace MicroServicesDemo
{
    public abstract class ServiceMonitor
    {
        public void ShutDownAllServices()
        {
        }

        public List<string> ServicesStatus(string serviceType)
        {
            return new List<string>();

        }

    }
}