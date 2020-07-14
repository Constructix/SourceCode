using System.Collections.Generic;

namespace MobileDemo.Services
{
    public interface IMobileService
    {
        IEnumerable<Models.Mobile> GetAll();
        Models.Mobile Add(Models.Mobile mobile);
    }
}