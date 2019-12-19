namespace ARK.DATA.BaseModel
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class BaseData
    {
        public bool IsDeleted { get; set; }
        public int CreateDate { get; set; }
        public int CreateUser { get; set; }
        public int? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public int? DeleteDate { get; set; }
        public int? DeleteUser { get; set; }
    }
}