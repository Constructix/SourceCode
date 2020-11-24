namespace AbnLookup
{
    public class AbnNameLookupRequest
    {
        public string NameOfEntity { get; set; }
        public int MaxResultsToReturn { get; set; }
        
        

        public AbnNameLookupRequest()
        {
            
        }

        public AbnNameLookupRequest(string nameOfEntity, int maxResultsToReturn)
        {
            NameOfEntity = nameOfEntity;
            MaxResultsToReturn = maxResultsToReturn;
        }
    }
}