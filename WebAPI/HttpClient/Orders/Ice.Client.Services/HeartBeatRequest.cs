using System;

namespace Ice.Client.Services
{
    public class HeartBeartRequest
    {

        public Guid JurisdictionId { get; set; }
        public HeartBeartRequest(Guid jurisdictionId)
        {
            Jurisdiction jurisdiction = new Jurisdiction { EndpointAddress = "https://localhost:43000/api/recipient/CheckheartBeat" };
            this.JurisdictionId = jurisdictionId;
        }
    }
}
