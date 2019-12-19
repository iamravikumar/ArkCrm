using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AccountCommunication : BaseModel.BaseData
    {
        public int ID { get; set; }

        [MaxLength(1024)]
        public string Value { get; set; }
        public bool IsDefault { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }

        public int? CommunicationTypeId { get; set; }
        public AccountCommunicationType CommunicationType { get; set; }        
    }
}

//email, ev tel, iş tel, cep tel