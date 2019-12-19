using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class ParameterList : BaseModel.BaseData
    {
        public int ID { get; set; }
        public int? ParentId { get; set; }
        public ParameterList Parent { get; set; }
        public int Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Value { get; set; }
        public bool IsActive { get; set; }
    }
}
