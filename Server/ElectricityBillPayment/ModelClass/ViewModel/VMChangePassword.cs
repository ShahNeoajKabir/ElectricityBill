using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VMChangePassword
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string RetypePassword { get; set; }
    }
}
