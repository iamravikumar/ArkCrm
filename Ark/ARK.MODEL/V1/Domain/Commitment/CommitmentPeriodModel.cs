using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Commitment
{
    public class CommitmentPeriodModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(64)]
        public string Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
    }
}
