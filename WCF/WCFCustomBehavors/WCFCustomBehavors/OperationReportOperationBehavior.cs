using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WCFCustomBehaviors.Service
{
    public class OperationReportOperationBehavior : IOperationBehavior
    {
        public void Validate(OperationDescription operationDescription)
        {
            
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            string serviceName = dispatchOperation.Parent.Type.Name;
            OperationReportInspector inspector =  new OperationReportInspector(serviceName);

            dispatchOperation.ParameterInspectors.Add(inspector);

        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            
        }
    }
}