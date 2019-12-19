using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Account
{
    public class AccountCommunicationModel : BaseModel
    {
        public int ID { get; set; }

        [MaxLength(1024)]
        public string Value { get; set; }
        public bool IsDefault { get; set; }

        public int? CustomerId { get; set; }
        public CustomerModel Customer { get; set; }

        public int? AccountId { get; set; }
        public AccountModel Account { get; set; }

        public int? CommunicationTypeId { get; set; }
        public AccountCommunicationTypeModel CommunicationType { get; set; }
    }
}
