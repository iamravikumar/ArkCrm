using ARK.CORE;

namespace ARK.DATA.Models.BaseModel
{
    /// <summary>
    /// Service Base class for entities
    /// </summary>
    public abstract partial class ServiceBaseData : BaseEntity
    {
        public bool IsDeleted { get; set; }
        public int CreateDate { get; set; }
        public int CreateUser { get; set; }
        public int? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public int? DeleteDate { get; set; }
        public int? DeleteUser { get; set; }
        //Service
        public int? StatusId { get; set; }
        public System.DateTime? ServiceUpdateDate { get; set; }
    }
}