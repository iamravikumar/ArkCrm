using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        [MaxLength(128)]
        public string RoleCode { get; set; }
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public int CreateDate { get; set; }
        public int CreateUser { get; set; }
        public int? UpdateDate { get; set; }
        public int? UpdateUser { get; set; }
        public int? DeleteDate { get; set; }
        public int? DeleteUser { get; set; }
    }
}
