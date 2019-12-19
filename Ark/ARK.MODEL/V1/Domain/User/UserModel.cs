using System;
using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.User
{
    public class UserModel
    {
        public int Id { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string SecurityStamp { get; set; }
        public string PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
        public string NormalizedEmail { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string UserName { get; set; }
        
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        [MaxLength(1024)]
        public string FullName { get; set; }

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
