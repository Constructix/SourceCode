using System.Collections.Generic;
using AbnLookup.JsonResponseEntities;

namespace AbnLookup.ResponseEntities
{
    public class MatchingNameLookupResponse
    {
        public string Message { get; set; }

        public List<MachingNameEntity> Names { get; set; }
    }

    public class ABNLookupResponse
    {
       
    }
}