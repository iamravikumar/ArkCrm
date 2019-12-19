namespace ARK.DATA.Models
{
    public class WorkOrder : BaseModel.BaseData
    {
        public int ID { get; set; }


        public int? Priority { get; set; }
        public string Description { get; set; }

        public int WorkStartDate { get; set; }
        public int WorkEndDate { get; set; }

        public int AgainStartDate { get; set; }
        public int AgainEndDate { get; set; }

        public int CompleteUser { get; set; }
        public int CompleteDate { get; set; }

        public int? ParentId { get; set; }
        public WorkOrder Parent { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int? WorkOrderStatusId { get; set; }
        public WorkOrderStatus WorkOrderStatus { get; set; }
        public int? TypeId { get; set; }
        public WorkOrderType WorkOrderType { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public int? RetailerId { get; set; }
        public Retailer Retailer { get; set; }

        public virtual System.Collections.Generic.ICollection<WorkOrderProduct> WorkOrderProducts { get; set; }
    }
}
