namespace AbnLookup
{
    public class NameLookupRequest
    {
        public string NameOfEntity { get; set; }
        public int MaxResultsToReturn { get; set; }
        
        

        public NameLookupRequest()
        {
            
        }

        public NameLookupRequest(string nameOfEntity, int maxResultsToReturn)
        {
            NameOfEntity = nameOfEntity;
            MaxResultsToReturn = maxResultsToReturn;
        }
    }
}