using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AccountView : BaseModel.BaseData
    {
        public int ID { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; } //2526132825@fullnet
        [MaxLength(25)]
        public string ModemPassword { get; set; }
        [MaxLength(256)]
        public string EmailAddress { get; set; }

        [MaxLength(50)]
        public string XdslNo { get; set; } // tt hizmet no
        [MaxLength(50)]
        public string PstnNo { get; set; } //telefon no
       
        //ALTYAPI
        [MaxLength(25)]
        public string CentralName { get; set; } // FETHIYE-124 // santral adı
        [MaxLength(25)]
        public string PopNoName { get; set; } //318- 48FETHIYE
        [MaxLength(25)]
        public string DslamNoType { get; set; } //50- MA5616 - Outdoor
        [MaxLength(25)]
        public string ShelfNo { get; set; } //1 -SD202_T7
        [MaxLength(25)]
        public string BoxCardNo { get; set; } //4- VDLE
        [MaxLength(25)]
        public string PortNo { get; set; } //17
        //ALTYAPI

        [MaxLength(2)]
        public string InvoiceCreationDay { get; set; } // fatura oluşturma tarihi
        [MaxLength(50)]
        public string MacAddress { get; set; }
        public short NumberOfUsers { get; set; }
        public bool HasStaticIP { get; set; }
        [MaxLength(50)]
        public string StaticIPAddress { get; set; }

        [MaxLength(50)]
        public string VLANIP { get; set; }
        //online işlem merkezi şifresi
        //ödeme türü

        public int? RegisterDate { get; set; } // hizmet başlangıç tarihi
        public int? LossDate { get; set; } //müşteri kayıp tarihi
        public int? LossReasonId { get; set; } //müşteri kayıp nedeni



        public int? AccountTypeId { get; set; } // hesap türü bireysel - kurumsal
        public AccountType AccountType { get; set; }

        public int? AccountStatusId { get; set; }
        public AccountStatus AccountStatus { get; set; } // hesabın statüsü
        public int? MikrotikId { get; set; }
        public Mikrotik Mikrotik { get; set; }
        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public int? SpeedId { get; set; }
        public CampaignSpeed Speed { get; set; }



        public int? ReceiverId { get; set; }
        public Receiver Receiver { get; set; }
        public int? StationId { get; set; }
        public Station Station { get; set; }
        public int? RetailerId { get; set; }
        public Retailer Retailer { get; set; }
        public int? ProfileId { get; set; }
        public AccountProfile Profile { get; set; }
    }
}
