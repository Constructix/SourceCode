using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerInspector
{
    public class StockInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            StringBuilder builder = new StringBuilder();


            builder.Append($"DateTime of Request: {DateTime.Now.ToUniversalTime().ToString("O")} ");
            builder.AppendLine("Inspector called.... ");
            builder.AppendLine(request.ToString());
            System.IO.File.AppendAllText(@"D:\Temp\StockInspector.txt",builder.ToString());
            
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
           
        }

       
    }


    public class StockInspectorBehavior : IEndpointBehavior
    {
        public void Validate(ServiceEndpoint endpoint)
        {
           
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            StockInspector inspector  = new StockInspector();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            
        }
    }


    public class StockInspectorConfigurationSection : BehaviorExtensionElement, IServiceBehavior
    {
        protected override object CreateBehavior()
        {
           return new StockInspectorBehavior();
        }

        public override Type BehaviorType => typeof(StockInspectorBehavior);

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
         
        }
    }
}
