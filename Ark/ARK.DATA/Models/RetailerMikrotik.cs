namespace ARK.DATA.Models
{
    public class RetailerMikrotik : BaseModel.BaseData
    {
        public int ID { get; set; }

        public int? RetailerId { get; set; }
        public Retailer Retailer { get; set; }
        public int? MikrotikId { get; set; }
        public Mikrotik Mikrotik { get; set; }
    }
}
