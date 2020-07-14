using System.Collections.Generic;
using System.Linq;
using ScopedDemo.Models;

namespace ScopedDemo.Services
{
    public class MobileService : IMobileService
    {
        private List<Mobile> _mobileList;
        public MobileService()
        {
            _mobileList = new List<Mobile>()
            {
                new Mobile()  { Id = 1, Name = "Samsung", Model="Note-10",    Price="70,000" },
                new Mobile()  { Id = 2, Name = "Nokia",   Model="S6",         Price="20,000" },
                new Mobile()  { Id = 3, Name = "Xiaomi",  Model="Note-8",    Price="21,999" }
            };
        }

        public IEnumerable<Mobile> GetAll() => _mobileList;


        public Mobile Add(Mobile mobile) => GenerateNewMobile(mobile);
        

        private Mobile GenerateNewMobile(Mobile mobile)
        {
            mobile.Id = _mobileList.Max(e => e.Id) + 1;
            _mobileList.Add(mobile);
            return mobile;
        }
    }
}