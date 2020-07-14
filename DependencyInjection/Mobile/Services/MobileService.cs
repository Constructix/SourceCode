using System.Collections.Generic;
using System.Linq;

namespace MobileDemo.Services
{
    public class MobileService : IMobileService
    {
        private List<Models.Mobile> _mobileList;

        public MobileService()
        {
            _mobileList = new List<Models.Mobile>()
            {
                new Models.Mobile() { id = 1, name = "Samsung", model="Note-10",    price="70,000" },
                new Models.Mobile() { id = 2, name = "Nokia",   model="S6",         price="20,000" },
                new Models.Mobile()  { id = 3, name = "Xiaomi",  model="Note-8",    price="21,999" }
            };
        }
        public Models.Mobile Add(Models.Mobile mobile)
        {
            mobile.id = _mobileList.Max(e => e.id) + 1;
            _mobileList.Add(mobile);
            return mobile;
        }
        public IEnumerable<Models.Mobile> GetAll()
        {
            return _mobileList;
        }
    }
}