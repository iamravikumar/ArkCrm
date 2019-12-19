using ARK.CORE;

namespace ARK.DATA.Models
{
    public class CustomerView : BaseEntity
    {
        public int ID { get; set; }
        public long? TTCustomerNo { get; set; }
        public int? CustomerId { get; set; }
        public string FullName { get; set; }
        public string CitizenNumber { get; set; }
        public int? RetailerId { get; set; }
        public string RetailerName { get; set; }

        //Account
        public string PstnNo { get; set; }
        public string XdslNo { get; set; }
        public int? RegisterDate { get; set; } // hizmet başlangıç tarihi


        // campaign
        public string InvoiceTypeName { get; set; }
        public string CampaignName { get; set; }
        public string SpeedName { get; set; }
        public string AccountStatus { get; set; }
        public string AccountType { get; set; }
    }
}
