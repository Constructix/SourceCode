namespace AbnLookup
{
    public class MatchingNameLookupRequest
    {
        public string NameOfEntity { get; set; }
        public int MaxResultsToReturn { get; set; }
        
        

        public MatchingNameLookupRequest()
        {
            
        }

        public MatchingNameLookupRequest(string nameOfEntity, int maxResultsToReturn)
        {
            NameOfEntity = nameOfEntity;
            MaxResultsToReturn = maxResultsToReturn;
        }
    }
}