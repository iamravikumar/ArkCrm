using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Campaign
{
    public class CampaignParameterListModel : BaseModel
    {
        public int ID { get; set; }
        public int? MainId { get; set; }
        public int? ParentId { get; set; }
        public int Code { get; set; }
        [MaxLength(512)]
        public string CodeName { get; set; }
        [MaxLength(512)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Value { get; set; }
        public bool IsActive { get; set; }
    }
}
