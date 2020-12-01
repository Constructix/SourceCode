using System.Collections.Generic;

namespace AbnLookup.DataModels.JsonResponseEntities
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