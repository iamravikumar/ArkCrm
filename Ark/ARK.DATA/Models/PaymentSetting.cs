using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class PaymentSetting : BaseModel.BaseData
    {
        public int ID { get; set; }

        [MaxLength(128)]
        public string Name { get; set; } // Payment Firma ismi
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }

        public int MerchantId { get; set; } // payment magaza kodu
        [MaxLength(512)]
        public string OkUrl { get; set; }//Basarili sonuç alinirsa, yönledirelecek sayfa
        [MaxLength(512)]
        public string FailUrl { get; set; }//Basarisiz sonuç alinirsa, yönledirelecek sayfa

        [MaxLength(512)]
        public string UserName { get; set; } //  api rollü kullanici adı
        [MaxLength(512)]
        public string Password { get; set; } //  api rollü kullanici sifresi
        [MaxLength(512)]
        public string g3DServerUrl { get; set; } // 3d api url




        public bool IsSmsSystemActive { get; set; } // Sms sistemi aktif mi
        public bool IsSmsSystemSecurityActive { get; set; } // Sms güvenli sistemi aktif mi
        public string MemberNo { get; set; } //Üye no
        public string SenderName { get; set; } // FULLNET sms gönderenin ismi

        public double? SmsBalancePrice { get; set; } // Sms Bakiyesi
        public double? SmsUnitPrice { get; set; } // Sms birim fiyatı


        public string ApiUsername { get; set; } // api username
        public string ApiPassword { get; set; } // api password

    }
}
