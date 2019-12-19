using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain
{
    public class CustomerSourceModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public int? Code { get; set; }
    }
}