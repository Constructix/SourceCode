namespace AbnLookup.DataModels.JsonResponseEntities
{
    public class MachingNameEntity
    {
        public string Abn { get; set; }
        public string AbnStatus { get; set; }
        public bool IsCurrent { get; set; }
        public string Name { get; set; }
        public string NameType { get; set; }
        public string Postcode { get; set; }
        public int Score { get; set; }
        public string State { get; set; }
    }
}