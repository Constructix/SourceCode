using System.Collections.Generic;
using GeoLib.Contracts;

namespace GeoLib.Services
{
    public class GeoManager : IGeoService
    {
        public ZipCodeData GetZipInfo(string zip)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetStates(bool primaryOnly)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            throw new System.NotImplementedException();
        }
    }
}