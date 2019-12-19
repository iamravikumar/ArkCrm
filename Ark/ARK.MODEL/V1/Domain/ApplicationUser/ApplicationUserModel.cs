using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.ApplicationUser
{
    public class ApplicationUserModel
    {
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
        [MaxLength(256)]
        public string MidName { get; set; }
        [MaxLength(256)]
        public string TaxOffice { get; set; }
        [MaxLength(256)]
        public string TaxNumber { get; set; }
        public int? BirthDate { get; set; }
        [MaxLength(256)]
        public string IdentityNumber { get; set; }
        public short GenderId { get; set; }
        public string ReferenceUserId { get; set; }
        public int? LockoutEndDate { get; set; }

        public bool IsDeleted { get; set; }
        public int CreateDate { get; set; }
        public int CreateUser { get; set; }
        public int? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public int? DeleteDate { get; set; }
        public int? DeleteUser { get; set; }
    }
}
