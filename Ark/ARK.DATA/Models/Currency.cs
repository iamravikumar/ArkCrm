using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class Currency : BaseModel.BaseData
    {
        public int ID { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
        public bool IsActive { get; set; }
    }
}