namespace AbnLookup
{
    public class ABNLookupRequest
    {
        public string ABN { get; set; }

        public ABNLookupRequest() { }
        public ABNLookupRequest(string abn) => ABN = abn;
    }
}