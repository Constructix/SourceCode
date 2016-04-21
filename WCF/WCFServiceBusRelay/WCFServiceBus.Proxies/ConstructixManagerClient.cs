using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFServiceBus.Contracts;

namespace WCFServiceBus.Proxies
{
    public class ConstructixManagerClient : ClientBase<IConstructixManager>, IConstructixManager
    {
        public int Add(int number1, int number2)
        {
            return Channel.Add(number1, number2);
        }
    }
}
