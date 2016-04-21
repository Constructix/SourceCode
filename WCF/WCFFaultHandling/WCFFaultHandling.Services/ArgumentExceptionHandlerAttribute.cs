using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace WCFFaultHandling.Services
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ArgumentExceptionHandlerAttribute : Attribute, IErrorHandler, IServiceBehavior
    {


        private object thisLock = new object();
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {

            if (error is ArgumentException)
            {
                FaultException<ArgumentException> faultException =
                    new FaultException<ArgumentException>(new ArgumentException(error.Message));

                fault = Message.CreateMessage(version, faultException.CreateMessageFault(), faultException.Action);
            }
            else
                fault = null;

        }

        public bool HandleError(Exception error)
        {

            lock (thisLock)
            {

                string logFileName = ConfigurationManager.AppSettings["logErrorFile"];

                ArgumentException argex = error as ArgumentException;
                
                StringBuilder builder = new StringBuilder();
                if (argex != null)
                {
                    builder.AppendLine(string.Format("Exception : {0} Raised: {1}", argex.Message,
                        DateTime.Now.ToUniversalTime().ToString("O")));

                    using (FileStream fs = new FileStream(logFileName, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            writer.Write(builder.ToString());
                        }
                    }
                }
            }
            return true;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = (ChannelDispatcher)channelDispatcherBase;
                channelDispatcher.ErrorHandlers.Add(this);
            }
        }
    }
}