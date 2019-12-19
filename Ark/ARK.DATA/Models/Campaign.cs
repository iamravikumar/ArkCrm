using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class Campaign : BaseModel.BaseData
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
        public int? CampaignCode { get; set; }
        [MaxLength(256)]
        public string CampaignCodeName { get; set; }

        public int? CampaignStartDate { get; set; }
        public int? CampaignEndDate { get; set; }
        public bool VisibleOnWebsite { get; set; } // websitesinde görünür mü        
        public bool IsTest { get; set; } //deneme tarifisi mi

        


        public int? CommitmentPromotionId { get; set; } // taahhütsüz promosyon ay
        public virtual CommitmentPromotion CommitmentPromotion { get; set; }
        public int? CommitmentPeriodId { get; set; } // taahhüt periyodu - aylık/yıllık/günlük /tarife süresi
        public virtual CommitmentPeriod CommitmentPeriod { get; set; }
        public int? InvoiceTypeId { get; set; } // fatura türü - ön ödemeli / Fatura
        public virtual InvoiceType InvoiceType { get; set; }
        public int? InfrastructureId { get; set; } // altyapı fttx gpon adsl vdsl
        public virtual Infrastructure Infrastructure { get; set; }

        public int? SaleChannelId { get; set; } // AL-SAT, VAE, WIFI, YAPA
        public CampaignParameterList SaleChannel { get; set; }
        public int? CampaignTypeId { get; set; } // adsl, vdsl vs.
        public CampaignParameterList CampaignType { get; set; }
        public int? CampaignPaymentTypeId { get; set; } // kampanya tipi ör: ön ödemeli, faturalı, taahhütlü, kart tarifesi, adsl, ön ödemeli aylık, vdsl, fiber, metro
        public CampaignParameterList CampaignPaymentType { get; set; }
    }
}
