using ARK.MODEL.V1.Domain.Commitment;
using ARK.MODEL.V1.Domain.Infrastructure;
using ARK.MODEL.V1.Domain.Invoice;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Campaign
{
    public class CampaignModel : BaseModel
    {
        //double aylikSabitUcret;  // ücret
        //int hiz;                 // hız
        //string hizAciklama;      // hiz aciklama
        //string paketAdi;         // hiz
        //int paketTuru;           // 
        //int tarifeTuru;          // kampanya

        public int ID { get; set; }

        // kampanya genel bilgileri
        [MaxLength(256)]
        public string CampaignName { get; set; }
        [MaxLength(256)]
        public string CampaignCode { get; set; }
        public int? CampaignStartDate { get; set; }
        public int? CampaignEndDate { get; set; }
        public bool VisibleOnWebsite { get; set; } // websitesinde görünür mü        
        public bool IsTest { get; set; } //deneme tarifisi mi




        public int? CommitmentPromotionId { get; set; } // taahhütsüz promosyon ay
        public virtual CommitmentPromotionModel CommitmentPromotion { get; set; }
        public int? CommitmentPeriodId { get; set; } // taahhüt periyodu - aylık/yıllık/günlük /tarife süresi
        public virtual CommitmentPeriodModel CommitmentPeriod { get; set; }
        public int? InvoiceTypeId { get; set; } // fatura türü - ön ödemeli / Fatura
        public virtual InvoiceTypeModel InvoiceType { get; set; }
        public int? InfrastructureId { get; set; } // altyapı fttx gpon adsl vdsl
        public virtual InfrastructureModel Infrastructure { get; set; }

        public int? SaleChannelId { get; set; } // AL-SAT, VAE, WIFI, YAPA
        public CampaignParameterListModel SaleChannel { get; set; }
        public int? CampaignTypeId { get; set; } // adsl, vdsl vs.
        public CampaignParameterListModel CampaignType { get; set; }
        public int? CampaignPaymentTypeId { get; set; } // kampanya tipi ör: ön ödemeli, faturalı, taahhütlü, kart tarifesi, adsl, ön ödemeli aylık, vdsl, fiber, metro
        public CampaignParameterListModel CampaignPaymentType { get; set; }
    }
}
