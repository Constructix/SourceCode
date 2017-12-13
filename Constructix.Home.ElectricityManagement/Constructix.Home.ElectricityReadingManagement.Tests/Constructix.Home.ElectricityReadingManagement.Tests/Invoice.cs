namespace Constructix.Home.ElectricityReadingManagement
{
    public class Invoice
    {
        public Invoice()
        {
        }

        public Invoice(decimal supplyCharge)
        {
            SupplyCharge = supplyCharge;
        }

        public decimal SupplyCharge { get; set; }
        public decimal ElectricityUsage { get; set; }
    }
}