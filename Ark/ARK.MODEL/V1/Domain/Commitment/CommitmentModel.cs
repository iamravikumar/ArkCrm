using ARK.MODEL.V1.Domain.Account;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Commitment
{
    public class CommitmentModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string CommitmentNumber { get; set; } //sözleşme numarası
        [MaxLength(128)]
        public string ContractDescription { get; set; }

        public int? CommitmentStartDate { get; set; }
        public int? CommitmentEndDate { get; set; }



        public int? CommitmentTypeId { get; set; }
        public CommitmentTypeModel CommitmentType { get; set; }
        public int? CommitmentStatusId { get; set; }
        public CommitmentStatusModel CommitmentStatus { get; set; }
        public int? AccountId { get; set; }
        public AccountModel Account { get; set; }
    }
}
