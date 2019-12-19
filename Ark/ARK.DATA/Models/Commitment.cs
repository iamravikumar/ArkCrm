using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class Commitment : BaseModel.BaseData
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string CommitmentNumber { get; set; } //sözleşme numarası
        [MaxLength(128)]
        public string ContractDescription { get; set; }

        public int? CommitmentStartDate { get; set; }
        public int? CommitmentEndDate { get; set; }



        public int? CommitmentTypeId { get; set; }
        public CommitmentType CommitmentType { get; set; }
        public int? CommitmentStatusId { get; set; }
        public CommitmentStatus CommitmentStatus { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
    }
}
