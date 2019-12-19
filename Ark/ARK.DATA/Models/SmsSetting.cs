using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class SmsSetting
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string Name { get; set; } // Sms Firma ismi
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }

        public bool IsSmsSystemActive { get; set; } // Sms sistemi aktif mi
        public bool IsSmsSystemSecurityActive { get; set; } // Sms güvenli sistemi aktif mi
        public string MemberNo { get; set; } //Üye no
        public string SenderName { get; set; } // FULLNET sms gönderenin ismi

        public double? SmsBalancePrice { get; set; } // Sms Bakiyesi
        public double? SmsUnitPrice { get; set; } // Sms birim fiyatı


        public string ApiUsername { get; set; } // api username
        public string ApiPassword { get; set; } // api password

        public int? SmsCorporateId { get; set; }
        public SmsCorporate SmsCorporate { get; set; }
    }
}
