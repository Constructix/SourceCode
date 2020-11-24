using System.Collections.Generic;

namespace AbnLookup.ResponseEntities
{
    public class NameLookupResponse
    {
        public string Message { get; set; }

        public List<AbnEntity> Names { get; set; }
    }
}