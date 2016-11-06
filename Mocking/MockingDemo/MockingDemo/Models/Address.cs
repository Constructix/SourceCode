namespace MockingDemo
{
    public class Address : BaseEntity<int>
    {
        
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        
    }
}