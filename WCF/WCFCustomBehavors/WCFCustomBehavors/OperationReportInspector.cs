using System;
using System.ServiceModel.Dispatcher;

namespace WCFCustomBehaviors.Service
{
    public class OperationReportInspector : IParameterInspector
    {

        private readonly string _serviceName ;


        public OperationReportInspector()
        {
            
        }

        public OperationReportInspector(string serviceName)
        {
            _serviceName = serviceName; 
        }
        public object BeforeCall(string operationName, object[] inputs)
        {
            return null;
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} - '{_serviceName}.{operationName}' operation called.");
        }

    }
}