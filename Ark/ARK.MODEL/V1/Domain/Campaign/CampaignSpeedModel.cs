using ARK.MODEL.V1.Domain.Currency;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Campaign
{
    public class CampaignSpeedModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public int? Code { get; set; }



        [MaxLength(128)]
        public string AKNUploadSpeedLimit { get; set; }
        [MaxLength(128)]
        public string AKNDownloadSpeedLimit { get; set; }
        [MaxLength(128)]
        public string ChangeableUploadSpeedLimit { get; set; }
        [MaxLength(128)]
        public string ChangeableDownloadSpeedLimit { get; set; }

        // kampanya kota bilgileri
        [MaxLength(128)]
        public string DownloadSpeedLimit { get; set; } // download hız limiti
        [MaxLength(128)]
        public string UploadSpeedLimit { get; set; } // upload hız limiti
        public int? SpeedLimitValue { get; set; } // hız limiti tt kodu
        [MaxLength(128)]
        public string SpeedLimit { get; set; } //tarife limiti 100 mb
        [MaxLength(128)]
        public string TimeLimit { get; set; } //süre limiti ör: 10 dk



        public double CommitmentPrice { get; set; } // taahhütlü fiyat
        public double CommitmentlessPrice { get; set; } // taahhütsüz fiyat   
        public double PromotionPrice { get; set; } // promosyon fiyatı
        public double PurchaseMonthlyPrice { get; set; } // aylık alış fiyatı

        // değişken kampanya bilgileri
        public bool? IsChangeableCampaign { get; set; }
        public int? ChangeableStartTime { get; set; }
        public int? ChangeableEndTime { get; set; }

        // AKN Bilgileri
        public bool? IsAKNActive { get; set; }
        [MaxLength(128)]
        public string AKNQuota { get; set; }


        // kampanya patlatma işlemleri
        [MaxLength(128)]
        public string ExplodePointUpload { get; set; } // patlama noktası upload
        [MaxLength(128)]
        public string ExplodePointDownload { get; set; } // patlama noktası download
        [MaxLength(128)]
        public string ExplodeThresholdUpload { get; set; } // patlama eşiği upload
        [MaxLength(128)]
        public string ExplodeThresholdDownload { get; set; } // patlama eşiği download

        // kampanya ücret bilgileri
        public double CampaignPrice { get; set; }
        [MaxLength(128)]
        public string BillingPaymentMinLimit { get; set; }
        [MaxLength(128)]
        public string BankComission { get; set; }
        [MaxLength(128)]
        public string AccessPointDeviceIP { get; set; }

        public int? CurrencyId { get; set; } // kur - TL
        public virtual CurrencyModel Currency { get; set; }

        public int? CampaignId { get; set; }
        public CampaignModel Campaign { get; set; }
        public int? SpeedLimitTypeId { get; set; } // hız limiti aylık / günlük
        public SpeedLimitTypeModel SpeedLimitType { get; set; }
    }
}
