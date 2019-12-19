using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class Parameter : BaseModel.BaseData
    {
        public int ID { get; set; }
        public int? Code { get; set; }
        [MaxLength(512)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string CodeName { get; set; }
        [MaxLength(512)]
        public string Value { get; set; }
        [MaxLength(128)]
        public string Unit { get; set; }
    }
}
