using ARK.MODEL.V1.Domain.Campaign;
using ARK.MODEL.V1.Domain.Mikrotik;
using ARK.MODEL.V1.Domain.Receiver;
using ARK.MODEL.V1.Domain.Retailer;
using ARK.MODEL.V1.Domain.Station;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Account
{
    public class AccountModel : BaseModel
    {
        public int ID { get; set; }
        public int? CustomerId { get; set; }
        public CustomerModel Customer { get; set; }

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
        public AccountTypeModel AccountType { get; set; }

        public int? AccountStatusId { get; set; }
        public AccountStatusModel AccountStatus { get; set; } // hesabın statüsü
        public int? MikrotikId { get; set; }
        public MikrotikModel Mikrotik { get; set; }
        public int? CampaignId { get; set; }
        public CampaignModel Campaign { get; set; }
        public int? SpeedId { get; set; }
        public CampaignSpeedModel Speed { get; set; }



        public int? ReceiverId { get; set; }
        public ReceiverModel Receiver { get; set; }
        public int? StationId { get; set; }
        public StationModel Station { get; set; }
        public int? RetailerId { get; set; }
        public RetailerModel Retailer { get; set; }
        public int? ProfileId { get; set; }
        public AccountProfileModel Profile { get; set; }
    }
}
