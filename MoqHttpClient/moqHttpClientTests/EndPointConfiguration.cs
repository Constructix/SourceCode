using System.Collections.Generic;

namespace moqHttpClientTests
{
    public class EndPointConfiguration
    {
        public List<EndPoint> ServiceEndpoints { get; set; }

        public EndPointConfiguration()
        {
            ServiceEndpoints = new List<EndPoint>();
        }
    }
}