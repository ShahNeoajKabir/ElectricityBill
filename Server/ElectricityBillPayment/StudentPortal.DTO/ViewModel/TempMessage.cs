using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class TempMessage
    {
        public string UserId { get; set; }
        public long? SessionId { get; set; }
        public string Content { get; set; }
        public int? UserTypeId { get; set; }
    }
}
