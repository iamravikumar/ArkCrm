using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class WorkOrderProduct : BaseModel.BaseData
    {
        public int ID { get; set; }

        [MaxLength(128)]
        public string SerialNo { get; set; }

        public int? WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
