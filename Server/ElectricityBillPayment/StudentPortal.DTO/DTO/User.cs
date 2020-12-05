using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public int Gender { get; set; }
        public string UserTypeName { get; set; }
        public int UserTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        
        public virtual ICollection<UserRole> UserRole { get; set; }

    }
}