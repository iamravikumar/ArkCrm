using System.Collections.Generic;

namespace ARK.DATA.Models
{
    public class Order : BaseModel.BaseData
    {
        public int ID { get; set; }




        public bool HasStaticIP { get; set; } // statik ip var mı TRUE - FALSE
        public string ADSLPlaceToBuy { get; set; } // Adsl alınan yer

        public int? InstallmentPeriodId { get; set; } // taksit süresi
        public CampaignParameterList InstallmentPeriod { get; set; }
        public int? BusinessTypeId { get; set; } // iş türü
        public CampaignParameterList BusinessType { get; set; }
        public int? BusinessSubTypeId { get; set; } // alt iş türü
        public CampaignParameterList BusinessSubType { get; set; }
        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public int? SpeedId { get; set; }
        public CampaignSpeed Speed { get; set; }
        public int? OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; } //ön satış, beklemede, iptal,  
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? AcccountId { get; set; }
        public Account Account { get; set; }
        public int? AddressId { get; set; }
        public AccountAddress Address { get; set; }
        public int? SalesRepresentativeId { get; set; } // satış yapan kişi
        public ApplicationUser SalesRepresentative { get; set; }
        public int RetailerId { get; set; }
        public Retailer Retailer { get; set; }        
    }
}
