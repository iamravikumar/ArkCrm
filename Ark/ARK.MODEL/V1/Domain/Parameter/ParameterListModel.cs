using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Parameter
{
    public class ParameterListModel : BaseModel
    {
        public int ID { get; set; }
        public int? ParentId { get; set; }
        public ParameterListModel Parent { get; set; }
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
