using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
