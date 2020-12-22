using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VMRolePermission
    {
        public int RoleId { get; set; }
        public List<URL> Urls { get; set; }
    }
}
