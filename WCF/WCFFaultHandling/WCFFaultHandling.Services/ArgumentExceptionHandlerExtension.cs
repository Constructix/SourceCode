using System;
using System.ServiceModel.Configuration;

namespace WCFFaultHandling.Services
{
    public class ArgumentExceptionHandlerExtension :BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new ArgumentExceptionHandlerAttribute();
        }

        public override Type BehaviorType { get { return typeof (ArgumentExceptionHandlerAttribute); } }
    }
}