namespace AbnLookup
{
    public class ABNDetailsResponse
    {
        public string ABN { get; set; }
        public int MaxResultsToReturn { get; set; }



        public ABNDetailsResponse()
        {

        }

        public ABNDetailsResponse(string abn, int maxResultsToReturn)
        {
            ABN = abn;
            MaxResultsToReturn = maxResultsToReturn;
        }
    }
}