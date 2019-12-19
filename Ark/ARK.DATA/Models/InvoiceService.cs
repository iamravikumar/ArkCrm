using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class InvoiceService
    {
        public int ID { get; set; }
        
        

        

        public int? CampaignId { get; set; }
        [MaxLength(256)]
        public string CampaignName { get; set; }
        [MaxLength(256)]
        public string CampaignCode { get; set; }
        public Campaign Campaign { get; set; }
        public int? SpeedId { get; set; }
        public string SpeedName { get; set; }
        public int? SpeedCode { get; set; }
        public CampaignSpeed CampaignSpeed { get; set; }

        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        [MaxLength(128)]
        public string ProductCode { get; set; }
        public Product Product { get; set; }

        [MaxLength(128)]
        public string Price { get; set; }


        public double? AmountWithoutTax { get; set; } //vergisiz tutar
        public double? TotalAmount { get; set; } // tooplam tutar

        public int? AccountId { get; set; }
        public Account Account { get; set; }

        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
