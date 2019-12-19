namespace ARK.DATA.Models
{
    public class RetailerPrice : BaseModel.BaseData
    {
        public int ID { get; set; }

        public int? CampaignSpeedId { get; set; }
        public CampaignSpeed CampaignSpeed { get; set; }

        public int? RetailerId { get; set; }
        public Retailer Retailer { get; set; }

        public double Price { get; set; }
    }
}