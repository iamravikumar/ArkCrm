using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Receiver
{
    public class ReceiverModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public int? Code { get; set; }
    }
}