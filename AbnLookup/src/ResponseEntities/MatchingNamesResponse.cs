using System.Collections.Generic;

namespace AbnLookup.ResponseEntities
{
    public class MatchingNamesResponse
    {
        public string Message { get; set; }

        public List<AbnEntity> Names { get; set; }
    }
}