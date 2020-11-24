namespace AbnLookup
{
    public class AbnNameLookupRequest
    {
        public string NameOfEntity { get; set; }
        public int MaxResultsToReturn { get; set; }
        public string ResponseName { get; set; }
        

        public AbnNameLookupRequest()
        {
            
        }

        public AbnNameLookupRequest(string nameOfEntity, int maxResultsToReturn, string responseName)
        {
            NameOfEntity = nameOfEntity;
            MaxResultsToReturn = maxResultsToReturn;
            ResponseName = responseName;
        }
    }
}