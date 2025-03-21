﻿using System.Collections.Generic;
using System.ServiceModel;

namespace GeoLib.Contracts
{

    [ServiceContract]
    public interface IGeoService
    {
        [OperationContract]
        ZipCodeData GetZipInfo(string zip);
        
        [OperationContract]
        IEnumerable<string> GetStates(bool primaryOnly);

        [OperationContract(Name="GetZipByState")]
        IEnumerable<ZipCodeData> GetZips(string state);

        [OperationContract(Name="GetZipsForRange")]
        IEnumerable<ZipCodeData> GetZips(string zip, int range);




    }
}