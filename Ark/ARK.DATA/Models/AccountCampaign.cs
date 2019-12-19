using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARK.DATA.Models
{
    public class AccountCampaign : BaseModel.BaseData
    {
        public int ID { get; set; }

        // kampanya bilgileri kalıcılık olarak eklenir
        public int? CampaignId { get; set; }

        [MaxLength(256)]
        public string CampaignCodeName { get; set; }
        [MaxLength(256)]
        public string CampaignName { get; set; }
        public int? CampaignCode { get; set; }

        public int? SpeedId { get; set; }
        [MaxLength(128)]
        public string SpeedCodeName { get; set; }
        [MaxLength(128)]
        public string SpeedName { get; set; }
        public int? SpeedCode { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int? CampaignStartDate { get; set; }
        public int? CampaignEndDate { get; set; }

        public int? CommitmentPeriodCode { get; set; }
        [MaxLength(64)]
        public string CommitmentPeriodCodeName { get; set; }
        [MaxLength(64)]
        public string CommitmentPeriodName { get; set; }

        public int? CommitmentPromotionCode { get; set; }
        [MaxLength(128)]
        public string CommitmentPromotionCodeName { get; set; }
        [MaxLength(128)]
        public string CommitmentPromotionName { get; set; }

        public int? InfrastructureId { get; set; }
        public int? InfrastructureCode { get; set; }
        [MaxLength(128)]
        public string InfrastructureName { get; set; }
        [MaxLength(128)]
        public string InfrastructureCodeName { get; set; }
        




        public bool IsActive { get; set; }


        
        
        public int? ReceiverId { get; set; }
        public int? StationId { get; set; }
        public int? RetailerId { get; set; }
        public int? ProfileId { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }
    }
}
