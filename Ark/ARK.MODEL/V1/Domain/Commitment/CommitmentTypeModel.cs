using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Commitment
{
    public class CommitmentTypeModel
    {
        public int ID { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public int? Code { get; set; }
    }
}
